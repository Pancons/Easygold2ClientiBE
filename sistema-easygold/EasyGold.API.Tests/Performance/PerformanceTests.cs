
using Xunit;
using System.Diagnostics;

public class PerformanceTests
{
    [Fact]
    public void Function_ExecutesWithinTimeLimit()
    {
        // Arrange
        var stopwatch = new Stopwatch();
        var timeLimit = 1000; // 1000 milliseconds = 1 second

        // Act
        stopwatch.Start();
        PerformOperation();
        stopwatch.Stop();

        // Assert
        Assert.InRange(stopwatch.ElapsedMilliseconds, 0, timeLimit);
    }

    private void PerformOperation()
    {
        // Simulate a time-consuming operation
        System.Threading.Thread.Sleep(500); // Sleep for 500 milliseconds
    }
}
