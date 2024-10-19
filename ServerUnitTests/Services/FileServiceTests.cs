using Moq;
using FluentAssertions;
using Server.Models.Client;
using Server.Services.File;
using Server.Repositories.File;

namespace Server.UnitTests.Services
{
    public class FileServiceTests : IDisposable
    {
        private readonly Mock<FileRepository> _fileRepositoryMock = new();
        private readonly ClientDataModel _clientData;

        public FileServiceTests()
        {
            _clientData = new ClientDataModel()
            {
                Id = 23,
                LocationId = 4,
                ElectricityUsage = 12,
                ConnectionDateAndTime = "2023-01-01 12:00:00"
            };
        }

        [Fact]
        public void FileService_Should_Error_On_Missing_File_Repository_Constructor_Parameter()
        {
            var expectedError = new ArgumentNullException("fileRepository");

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(1, null!));

            ex.Message.Should().Be(expectedError.Message);
        }

        [Fact]
        public async Task WriteDataAsync_Should_Call_File_Repository()
        {
            // Arrange
            var fileService = new FileService(_clientData.Id, _fileRepositoryMock.Object);

            // Act
            await fileService.WriteDataAsync(_clientData);

            // Assert
            _fileRepositoryMock.Verify(x => x.WriteDataAsync(It.IsAny<string>(), It.IsAny<ClientDataModel>()), Times.Once);
        }

        [Fact]
        public async Task ReadDataAsync_Calls_File_Repository()
        {
            // Arrange
            var expectedData = new List<ClientDataModel>();
            string fileName = "testFile.json";
            var fileService = new FileService(_clientData.Id, _fileRepositoryMock.Object);

            _fileRepositoryMock.Setup(x => x.ReadDataAsync(fileName))
                .ReturnsAsync(expectedData);

            // Act
            var dataFromFile = await fileService.ReadDataAsync(fileName);

            // Assert 
            dataFromFile.Should().BeEquivalentTo(expectedData, because: "The data returned from ReadDataAsync should be a list of type ClientDataModel");
            _fileRepositoryMock.Verify(x => x.ReadDataAsync(It.IsAny<string>()), Times.Once);
        }

        public void Dispose()
        {
            _fileRepositoryMock.VerifyNoOtherCalls();
        }
    }
}
