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
        public void FileService_Should_ErrorOnMissing_FileRepository_ConstructorParaneter()
        {
            var expectedError = new ArgumentNullException("fileRepository");

            var ex = Assert.Throws<ArgumentNullException>(() => new FileService(1, null!));

            ex.Message.Should().Be(expectedError.Message);
        }

        [Fact]
        public async Task WriteDataAsync_ShouldCallFileRepository()
        {
            // Arrange
            var fileService = new FileService(_clientData.Id, _fileRepositoryMock.Object);

            // Act
            await fileService.WriteDataAsync(_clientData);

            // Assert
            _fileRepositoryMock.Verify(x => x.WriteDataAsync(It.IsAny<string>(), It.IsAny<ClientDataModel>()), Times.Once);
        }

        public void Dispose()
        {
            _fileRepositoryMock.VerifyNoOtherCalls();
        }
    }
}
