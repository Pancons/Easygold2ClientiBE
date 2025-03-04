
using Xunit;
using System.Threading.Tasks;

public class ConcurrencyTests
{
    private int sharedResource = 0;

    [Fact]
    public async Task ConcurrentOperations_DoNotCauseRaceConditions()
    {
        // Arrange
        var tasks = new Task[10];

        // Act
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() => IncrementSharedResource());
        }
        await Task.WhenAll(tasks);

        // Assert
        Assert.Equal(10, sharedResource);
    }

    private void IncrementSharedResource()
    {
        lock (this)
        {
            sharedResource++;
        }
    }
}
