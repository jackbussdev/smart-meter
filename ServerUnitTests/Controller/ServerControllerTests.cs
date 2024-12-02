using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Server.Controller.Server;
using Server.Factories;
using Server.Models.Client;
using Server.Repositories.File;
using Server.Services.DataCalculation;
using Server.Services.File;
using Server.Services.Http;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace ServerUnitTests.Controller
{
    public class ServerControllerTests : IDisposable
    {
        private readonly Mock<FileFactory> _fileFactoryMock = new();
        private readonly Mock<FileRepository> _fileRepositoryMock = new();
        private readonly Mock<IFileService> _fileServiceMock = new();
        private readonly Mock<IHttpService> _httpServiceMock = new();

        private readonly ClientDataModel _clientData;

        public ServerControllerTests()
        {
            _clientData = new ClientDataModel()
            {
                Id = 1,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2023-01-01 12:00:00"
            };
        }

        [Fact]
        public void IsClientDataValid_With_Valid_Data_Returns_True()
        {
            // Arrange
            var dataCalculationServiceMock = new DataCalculationService(_httpServiceMock.Object);
            var controller = new ServerController(_fileFactoryMock.Object, _fileRepositoryMock.Object, dataCalculationServiceMock);

            // Act
            var result = controller.IsClientDataValid(_clientData);

            // Assert
            result.Should().BeTrue(because: "All of the client data model paramters are present");
            controller.ValidationMessage.Should().BeNull();
        }

        [Fact]
        public void IsClientDataValid_With_Zero_Id_Returns_False()
        {
            // Arrange
            var dataCalculationServiceMock = new DataCalculationService(_httpServiceMock.Object);
            var controller = new ServerController(_fileFactoryMock.Object, _fileRepositoryMock.Object, dataCalculationServiceMock);

            var clientData = new ClientDataModel
            {
                Id = 0,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2024-10-02",
            };

            // Act
            var result = controller.IsClientDataValid(clientData);

            // Assert
            result.Should().BeFalse(because: "The client didnt have an id");
            controller.ValidationMessage.Should().Be("Error when verifying client");
        }

        [Fact]
        public void IsClientDataValid_With_Zero_Loation_Id_Returns_False()
        {
            // Arrange
            var dataCalculationServiceMock = new DataCalculationService(_httpServiceMock.Object);
            var controller = new ServerController(_fileFactoryMock.Object, _fileRepositoryMock.Object, dataCalculationServiceMock);

            var clientData = new ClientDataModel
            {
                Id = 1,
                LocationId = 0,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2024-10-02",
            };

            // Act
            var result = controller.IsClientDataValid(clientData);

            // Assert
            result.Should().BeFalse(because: "The client didnt have an location id");
            controller.ValidationMessage.Should().Be("Error when verifying client's location");
        }

        [Fact]
        public void IsClientDataValid_With_Empty_Connection_Date_And_Time_Returns_False_And_Error()
        {
            // Arrange
            var dataCalculationServiceMock = new DataCalculationService(_httpServiceMock.Object);
            var controller = new ServerController(_fileFactoryMock.Object, _fileRepositoryMock.Object, dataCalculationServiceMock);

            var clientData = new ClientDataModel
            {
                Id = 1,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = string.Empty,
            };

            // Act
            var result = controller.IsClientDataValid(clientData);

            // Assert
            result.Should().BeFalse(because: "The client didnt have a connection date and time");
            controller.ValidationMessage.Should().Be("Error when verifying client's time of connection");
        }

        [Fact]
        public async Task ProcessClientDataToFileAsync_Calls_File_Factory_And_File_Service()
        {
            // Arrange
            var dataCalculationServiceMock = new DataCalculationService(_httpServiceMock.Object);
            var controller = new ServerController(_fileFactoryMock.Object, _fileRepositoryMock.Object, dataCalculationServiceMock);

            var validClientData = new ClientDataModel
            {
                Id = 1,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2024-10-02"
            };

            // Set up the file factory mock to return the file service mock
            _fileFactoryMock
                .Setup(factory => factory.CreateFileService(It.IsAny<int>(), _fileRepositoryMock.Object))
                .Returns(_fileServiceMock.Object);

            // Act
            await controller.ProcessClientDataToFileAsync(validClientData);

            // Assert
            _fileFactoryMock.Verify(x => x.CreateFileService(It.IsAny<int>(), It.IsAny<FileRepository>()), Times.Once);
            _fileServiceMock.Verify(x => x.WriteDataAsync(It.IsAny<ClientDataModel>()), Times.Once);
        }

        [Fact]
        public void Process_Client_Data_With_Hashes_Matching()
        {
            // Arrange
            var dataCalculationServiceMock = new DataCalculationService(_httpServiceMock.Object);
            var controller = new ServerController(_fileFactoryMock.Object, _fileRepositoryMock.Object, dataCalculationServiceMock);

            var first = new ClientDataModel
            {
                Id = 1,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2024-10-02"
            };

            var second = first;

            string firstSerialised = JsonConvert.SerializeObject(first);
            string secondSerialised = JsonConvert.SerializeObject(second);

            byte[] firstSerialisedBytes = Encoding.UTF8.GetBytes(firstSerialised);
            byte[] secondSerialisedBytes = Encoding.UTF8.GetBytes(secondSerialised);

            byte[] firstHash;
            byte[] secondHash;

            using(SHA256 sha = SHA256.Create())
            {
                firstHash = sha.ComputeHash(firstSerialisedBytes);
                secondHash = sha.ComputeHash(secondSerialisedBytes);
            }

            // Act
            bool result = controller.DoHashesMatch(firstHash, secondHash);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Process_Client_Data_With_Hashes_Not_Matching()
        {
            // Arrange
            var dataCalculationServiceMock = new DataCalculationService(_httpServiceMock.Object);
            var controller = new ServerController(_fileFactoryMock.Object, _fileRepositoryMock.Object, dataCalculationServiceMock);

            var first = new ClientDataModel
            {
                Id = 1,
                LocationId = 2,
                ElectricityUsage = 3,
                ConnectionDateAndTime = "2024-10-02"
            };

            var second = new ClientDataModel
            {
                Id = 2,
                LocationId = 3,
                ElectricityUsage = 4,
                ConnectionDateAndTime = "2023-02-10"
            };

            string firstSerialised = JsonConvert.SerializeObject(first);
            string secondSerialised = JsonConvert.SerializeObject(second);

            byte[] firstSerialisedBytes = Encoding.UTF8.GetBytes(firstSerialised);
            byte[] secondSerialisedBytes = Encoding.UTF8.GetBytes(secondSerialised);

            byte[] firstHash;
            byte[] secondHash;

            using (SHA256 sha = SHA256.Create())
            {
                firstHash = sha.ComputeHash(firstSerialisedBytes);
                secondHash = sha.ComputeHash(secondSerialisedBytes);
            }

            // Act
            bool result = controller.DoHashesMatch(firstHash, secondHash);

            // Assert
            Assert.False(result);
        }

        public void Dispose()
        {
            _fileServiceMock.VerifyNoOtherCalls();
            _fileFactoryMock.VerifyNoOtherCalls();
        }
    }
}