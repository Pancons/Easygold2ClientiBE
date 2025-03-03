
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class UserControllerTests
{
    [Fact]
    public async void GetUsers_ReturnsOkResult()
    {
        // Arrange
        var controller = new UserController();

        // Act
        var result = await controller.GetUsers();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
