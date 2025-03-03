
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ModuleControllerTests
{
    [Fact]
    public async Task GetModules_ReturnsOkResult_WithListOfModules()
    {
        // Arrange
        var mockService = new Mock<IModuleService>();
        mockService.Setup(service => service.GetModulesAsync())
                   .ReturnsAsync(new List<ModuloDTO> { new ModuloDTO { Mdc_IDModulo = 1, Mde_Descrizione = "Module 1" } });
        var controller = new ModuleController(mockService.Object);

        // Act
        var result = await controller.GetModules();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var modules = Assert.IsType<List<ModuloDTO>>(okResult.Value);
        Assert.Single(modules);
    }
}
