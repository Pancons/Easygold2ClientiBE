
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AllegatoControllerTests
{
    [Fact]
    public async Task GetAllegati_ReturnsOkResult_WithListOfAllegati()
    {
        // Arrange
        var mockService = new Mock<IAllegatoService>();
        mockService.Setup(service => service.GetAllegatiAsync())
                   .ReturnsAsync(new List<AllegatoDTO> { new AllegatoDTO { All_IDAllegato = 1, All_NomeFile = "file.txt" } });
        var controller = new AllegatoController(mockService.Object);

        // Act
        var result = await controller.GetAllegati();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var allegati = Assert.IsType<List<AllegatoDTO>>(okResult.Value);
        Assert.Single(allegati);
    }
}
