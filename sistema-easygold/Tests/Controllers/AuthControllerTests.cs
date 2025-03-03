
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using System.Threading.Tasks;

public class AuthControllerTests
{
    [Fact]
    public async Task Login_ReturnsOkResult_WhenCredentialsAreValid()
    {
        // Arrange
        var mockService = new Mock<IAuthService>();
        mockService.Setup(service => service.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                   .ReturnsAsync(true);
        var controller = new AuthController(mockService.Object);

        // Act
        var result = await controller.Login("username", "password");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.True((bool)okResult.Value);
    }
}
