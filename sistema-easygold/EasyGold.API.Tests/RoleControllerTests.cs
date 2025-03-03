
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class RoleControllerTests
{
    [Fact]
    public async void GetRoles_ReturnsOkResult()
    {
        // Arrange
        var controller = new RoleController();

        // Act
        var result = await controller.GetRoles();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
