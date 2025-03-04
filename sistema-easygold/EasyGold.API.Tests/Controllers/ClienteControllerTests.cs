using Xunit;
using Moq;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Clients;
using EasyGold.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
public class ClienteControllerTests
{
    private readonly Mock<IClienteService> _mockClienteService;
    private readonly ClienteController _controller;

    public ClienteControllerTests()
    {
        _mockClienteService = new Mock<IClienteService>();
        _controller = new ClienteController(_mockClienteService.Object);
    }

    [Fact]
    public async Task List_ReturnsOkResult_WithClients()
    {
        // Arrange
        var request = new ClienteListRequest();

        // Corretto: Uso i nomi delle proprietà reali in ClienteDTO
        var clients = new List<ClienteDTO>
        {
            new ClienteDTO
            {
                Utw_IDClienteAuto = 1,
                Dtc_RagioneSociale = "Test Client"
            }
        };
        _mockClienteService.Setup(service => service.GetClientiListAsync(request))
            .ReturnsAsync(new ClienteListResult { Clienti = clients, Total = clients.Count });
        // Il tuo servizio restituisce una tuple (IEnumerable<ClienteDTO> Clients, int Count).
        // Quindi configuriamo il mock di conseguenza.

        // Act
        var result = await _controller.List(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task List_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var request = new ClienteListRequest();
        _mockClienteService
            .Setup(service => service.GetClientiListAsync(request))
            .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.List(request);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task SaveClient_ReturnsOkResult_WithClient()
    {
        // Arrange
        // Corretto: Uso proprietà reali in ClienteDettaglioDTO
        var clienteDto = new ClienteDettaglioDTO
        {
            Utw_IDClienteAuto = 1,
            Dtc_RagioneSociale = "New Client"
        };

        _mockClienteService
            .Setup(service => service.CreateClienteAsync(clienteDto))
            .ReturnsAsync(clienteDto);

        // Act
        var result = await _controller.SaveClient(clienteDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task SaveClient_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var clienteDto = new ClienteDettaglioDTO
        {
            Utw_IDClienteAuto = 1,
            Dtc_RagioneSociale = "New Client"
        };
        _controller.ModelState.AddModelError("error", "some error");

        // Act
        var result = await _controller.SaveClient(clienteDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task SaveClient_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var clienteDto = new ClienteDettaglioDTO
        {
            Utw_IDClienteAuto = 1,
            Dtc_RagioneSociale = "New Client"
        };

        _mockClienteService
            .Setup(service => service.CreateClienteAsync(clienteDto))
            .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.SaveClient(clienteDto);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task UpdateClient_ReturnsOkResult_WithUpdatedClient()
    {
        // Arrange
        var clienteDto = new ClienteDettaglioDTO
        {
            Utw_IDClienteAuto = 1,
            Dtc_RagioneSociale = "Updated Client"
        };

        _mockClienteService
            .Setup(service => service.UpdateClienteAsync(clienteDto.Utw_IDClienteAuto, clienteDto))
            .ReturnsAsync(clienteDto);

        // Act
        var result = await _controller.UpdateClient(clienteDto.Utw_IDClienteAuto, clienteDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task UpdateClient_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var clienteDto = new ClienteDettaglioDTO
        {
            Utw_IDClienteAuto = 1,
            Dtc_RagioneSociale = "Updated Client"
        };
        _controller.ModelState.AddModelError("error", "some error");

        // Act
        var result = await _controller.UpdateClient(clienteDto.Utw_IDClienteAuto, clienteDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateClient_ReturnsNotFound_WhenClientDoesNotExist()
    {
        // Arrange
        var clienteDto = new ClienteDettaglioDTO
        {
            Utw_IDClienteAuto = 1,
            Dtc_RagioneSociale = "Updated Client"
        };

        _mockClienteService
            .Setup(service => service.UpdateClienteAsync(clienteDto.Utw_IDClienteAuto, clienteDto))
            .ReturnsAsync((ClienteDettaglioDTO)null);

        // Act
        var result = await _controller.UpdateClient(clienteDto.Utw_IDClienteAuto, clienteDto);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task UpdateClient_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var clienteDto = new ClienteDettaglioDTO
        {
            Utw_IDClienteAuto = 1,
            Dtc_RagioneSociale = "Updated Client"
        };

        _mockClienteService
            .Setup(service => service.UpdateClienteAsync(clienteDto.Utw_IDClienteAuto, clienteDto))
            .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.UpdateClient(clienteDto.Utw_IDClienteAuto, clienteDto);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }
}
