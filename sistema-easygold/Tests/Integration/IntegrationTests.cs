
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

public class IntegrationTests
{
    [Fact]
    public async Task FullFlow_IntegrationTest()
    {
        // Arrange
        var mockClienteService = new Mock<IClienteService>();
        mockClienteService.Setup(service => service.GetClientiAsync())
                          .ReturnsAsync(new List<ClienteDTO> { new ClienteDTO { Utw_IDClienteAuto = 1, Dtc_RagioneSociale = "Client 1" } });

        var clienteController = new ClienteController(mockClienteService.Object);

        // Act
        var result = await clienteController.GetClienti();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var clienti = Assert.IsType<List<ClienteDTO>>(okResult.Value);
        Assert.Single(clienti);
    }
}
