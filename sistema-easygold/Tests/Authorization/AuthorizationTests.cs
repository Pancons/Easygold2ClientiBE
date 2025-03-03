
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EasyGold.API.Controllers;

public class AuthorizationTests
{
    [Fact]
    public void AuthenticatedUser_CanAccessProtectedResource()
    {
        // Arrange
        var controller = new ProtectedController();
        var user = new Mock<HttpContext>();
        user.Setup(u => u.User.Identity.IsAuthenticated).Returns(true);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = user.Object
        };

        // Act
        var result = controller.GetProtectedResource();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void UnauthenticatedUser_CannotAccessProtectedResource()
    {
        // Arrange
        var controller = new ProtectedController();
        var user = new Mock<HttpContext>();
        user.Setup(u => u.User.Identity.IsAuthenticated).Returns(false);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = user.Object
        };

        // Act
        var result = controller.GetProtectedResource();

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }
}

using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EasyGold.API.Controllers;

public class AuthorizationTests
{
    [Fact]
    public void AuthenticatedUser_CanAccessProtectedResource()
    {
        // Arrange
        var controller = new ProtectedController();
        var user = new Mock<HttpContext>();
        user.Setup(u => u.User.Identity.IsAuthenticated).Returns(true);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = user.Object
        };

        // Act
        var result = controller.GetProtectedResource();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
