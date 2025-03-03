
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class ModuleControllerTests
{
    [Fact]
    public async void GetModules_ReturnsOkResult()
    {
        // Arrange
        var controller = new ModuleController();

        // Act
        var result = await controller.GetModules();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
