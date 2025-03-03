
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class ClienteControllerTests
{
    [Fact]
    public async void GetClienti_ReturnsOkResult()
    {
        // Arrange
        var controller = new ClienteController();

        // Act
        var result = await controller.GetClienti();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
