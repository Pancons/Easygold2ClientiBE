using Xunit;
using Moq;
using EasyGold.API.Controllers;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
// 🔸 Importa il namespace dove sta ModuloDTO
using EasyGold.API.Models.Moduli;

public class ModuleControllerTests
{
    private readonly Mock<IModuloService> _mockModuloService;
    private readonly ModuleController _controller;

    public ModuleControllerTests()
    {
        _mockModuloService = new Mock<IModuloService>();
        _controller = new ModuleController(_mockModuloService.Object);
    }

    [Fact]
    public async Task GetModulesDropdown_ReturnsOkResult_WithModules()
    {
        // Arrange
        // 🔸 Ora usi "ModuloDTO", non "ModuleDTO"
        var modules = new List<ModuloDTO>
        {
            new ModuloDTO
            {
                Mdc_IDModulo = 1,
                Mde_Descrizione = "Test Module"
            }
        };

        // 🔸 Configura il mock con la lista di ModuloDTO
        _mockModuloService
            .Setup(service => service.GetAllAsync())
            .ReturnsAsync(modules);

        // Act
        var result = await _controller.GetModulesDropdown();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);

        
    }

    [Fact]
    public async Task GetModulesDropdown_ReturnsInternalServerError_OnException()
    {
        // Arrange
        _mockModuloService
            .Setup(service => service.GetAllAsync())
            .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.GetModulesDropdown();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }
}
