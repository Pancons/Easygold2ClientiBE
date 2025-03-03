
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class AllegatoControllerTests
{
    [Fact]
    public async void GetAllegati_ReturnsOkResult()
    {
        // Arrange
        var controller = new AllegatoController();

        // Act
        var result = await controller.GetAllegati();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
