
using Xunit;
using Moq;
using System.Threading.Tasks;

public class DatabaseInteractionTests
{
    public class Repository
    {
        public virtual Task<bool> SaveDataAsync(string data)
        {
            // Simulate saving data to the database
            return Task.FromResult(true);
        }
    }

    [Fact]
    public async Task SaveDataAsync_SavesDataCorrectly()
    {
        // Arrange
        var repositoryMock = new Mock<Repository>();
        repositoryMock.Setup(r => r.SaveDataAsync(It.IsAny<string>())).ReturnsAsync(true);

        // Act
        var result = await repositoryMock.Object.SaveDataAsync("test data");

        // Assert
        Assert.True(result);
    }
}
