
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class AuthControllerTests
{
    [Fact]
    public async void Login_ReturnsOkResult()
    {
        // Arrange
        var controller = new AuthController();

        // Act
        var result = await controller.Login();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
