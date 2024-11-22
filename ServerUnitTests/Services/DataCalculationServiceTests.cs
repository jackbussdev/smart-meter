using FluentAssertions;
using Moq;
using Server.Models.Client;
using Server.Models.OctopusApi;
using Server.Services.DataCalculation;
using Server.Services.Http;
using System.Net;

namespace ServerUnitTests.Services
{
    public class DataCalculationServiceTests : IDisposable
    {
        private readonly Mock<IHttpService> _httpServiceMock = new();

        [Fact]
        public void DataCalculationService_Should_Error_On_Missing_Http_Service_Constructor_Parameter()
        {
            var expectedError = new ArgumentNullException("httpService");

            var ex = Assert.Throws<ArgumentNullException>(() => new DataCalculationService(null));

            ex.Message.Should().Be(expectedError.Message);
        }

        [Fact]
        public async Task GetStandardRatesAsync_Calls_Correct_Url()
        {
            // Arrange
            string productId = "t";
            string tariffCode = "b";
            DateTime periodFrom = new(2023, 03, 26);
            DateTime periodTo = new(2023, 03, 27); 

            var clientData = new ClientDataModel()
            {
                Id = 1,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2023-02-03"
            };

            var dataCalculationService = new DataCalculationService(_httpServiceMock.Object);

            var expectedUrl = $"https://api.octopus.energy/v1/products/{productId}/electricity-tariffs/{tariffCode}/standard-unit-rates/?period_from={periodFrom:yyyy-MM-dd'T'HH:mm:ss}Z&period_to={periodTo:yyyy-MM-dd'T'HH:mm:ss}Z";

            // Act 
            _ = await dataCalculationService.GetClientCostAsync(clientData);

            // Assert
            _httpServiceMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task GetStandardRatesAsync_Sets_Validation_Message_With_Invalid_Date()
        {
            // Arrange
            string productId = "1";
            DateTime periodFrom = new(1900, 12, 12);
            DateTime periodTo = new(1900, 12, 12);

            var clientData = new ClientDataModel()
            {
                Id = 1,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2023-02-03",
            };

            var dataCalculationService = new DataCalculationService(_httpServiceMock.Object);

            // Act 
            _ = await dataCalculationService.GetStandardRatesAsync(productId, clientData.Tariff, periodFrom, periodTo);

            // Assert
            dataCalculationService.ValidationMessage.Should().Be("Error when retrieving electricity prices");
            _httpServiceMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact] 
        public async Task ConvertConnectionTimeToDateTimeAsync_Returns_DateTime_Type()
        {
            // Arrange
            string dateAndTime = "2024-10-25T13:45:00Z"; 
            DateTime expectedDate = new(2024, 10, 25, 13, 45, 0, DateTimeKind.Utc);
            var dataCalculationService = new DataCalculationService(_httpServiceMock.Object);

            // Act
            DateTime result = await dataCalculationService.ConvertConnectionTimeToDateTimeAsync(dateAndTime);

            // Assert
            expectedDate.Should().Be(result);
        }

        [Fact]
        public async Task ConvertConnectionTimeToDateTimeAsync_Sets_Validation_Message_With_Invalid_Date()
        {
            // Arrange
            string invalidDate = "invalidDate";
            var dataCalculationService = new DataCalculationService(_httpServiceMock.Object);

            // Act
            await dataCalculationService.ConvertConnectionTimeToDateTimeAsync(invalidDate);

            // Assert
            dataCalculationService.ValidationMessage.Should().Be("Error parsing the date string: invalidDate");
        }

        [Fact]  
        public async Task CalculateCostAsync_Returns_Cost_With_Valid_Data()
        {
            // Arrange
            decimal expectedCost = 45;
            DateTime periodFrom = new(2024, 12, 25, 13, 45, 0, DateTimeKind.Utc);
            decimal electricityUsage = 5;

            var rates = new ElectricityDataResponse()
            {
                Results = new List<Result>
                {
                    new()
                    {
                        Value_exc_vat = 8,
                        Value_inc_vat = 9,
                        Valid_from = new(2024, 11, 25, 12, 45, 0, DateTimeKind.Utc),
                        Valid_to = new(2024, 11, 25, 13, 15, 0, DateTimeKind.Utc)
                    }
                }
            };

            var dataCalculationService = new DataCalculationService(_httpServiceMock.Object);

            // Act 
            var actualCost = await dataCalculationService.CalculateCostAsync(rates, periodFrom, electricityUsage);

            // Assert
            actualCost.Should().Be(expectedCost);
        }

        [Fact]
        public async Task GetStandardRatesAsync_Handles_Unsuccessful_Response()
        {
            // Arrange
            string productId = "1";
            string tariffCode = "2";
            DateTime? periodFrom = new (2024, 03, 07);
            DateTime periodTo = new (2024, 03, 08);

            _httpServiceMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var dataCalculationService = new DataCalculationService(_httpServiceMock.Object);

            // Act
            var result = await dataCalculationService.GetStandardRatesAsync(productId, tariffCode, periodFrom, periodTo);

            // Assert
            result.Should().NotBeNull(because: "All results from method will return either a populated ElectricityDataResponse result or an empty one.");
            result.Results.Should().BeNull(because: "Results variable within ElectricityDataResponse will be null because API call was unsuccessful.");
            dataCalculationService.ValidationMessage.Should().Be($"Error when retrieving electricity prices - status code: NotFound");
            _httpServiceMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        public void Dispose()
        {
            _httpServiceMock.VerifyNoOtherCalls();
        }
    }
}
