
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClienteControllerTests
{
    [Fact]
    public async Task GetClienti_ReturnsOkResult_WithListOfClienti()
    {
        // Arrange
        var mockService = new Mock<IClienteService>();
        mockService.Setup(service => service.GetClientiAsync())
                   .ReturnsAsync(new List<ClienteDTO> { new ClienteDTO { Utw_IDClienteAuto = 1, Dtc_RagioneSociale = "Client 1" } });
        var controller = new ClienteController(mockService.Object);

        // Act
        var result = await controller.GetClienti();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var clienti = Assert.IsType<List<ClienteDTO>>(okResult.Value);
        Assert.Single(clienti);
    }
}
