using FluentAssertions;
using Moq;
using Server.Models.Client;
using Server.Services.DataCalculation;
using Server.Services.Http;

namespace ServerUnitTests.Services
{
    public class DataCalculationServiceTests
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
            _ = await dataCalculationService.CalculateClientCostAsync(clientData);

            // Assert
            _httpServiceMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
