using Xunit;
using Moq;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Ruoli;
using EasyGold.API.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Services.Interfaces;
public class RuoliControllerTests
{
    private readonly Mock<IRuoloService> _mockRoleService;
    private readonly RuoliController _controller;

    public RuoliControllerTests()
    {
        // Supponendo che RoleService abbia un costruttore senza parametri 
        // o con parametri mockabili
        _mockRoleService = new Mock<IRuoloService>();
        _controller = new RuoliController(_mockRoleService.Object);
    }

    [Fact]
    public async Task GetRoles_ReturnsOkResult_WithRoles()
    {
        // Arrange
        // SOSTITUISCI RoleDTO con RuoloDTO e le proprietà con Ur_IDRuolo, Ur_Descrizione
        var roles = new List<RuoloDTO>
        {
            new RuoloDTO
            {
                Ur_IDRuolo = 1,
                Ur_Descrizione = "Admin"
            }
        };

        _mockRoleService
            .Setup(service => service.GetAllRolesAsync())
            .ReturnsAsync(roles);

        // Act
        var result = await _controller.GetRoles();

        var okResult = Assert.IsType<OkObjectResult>(result);
        dynamic returnValue = okResult.Value;
        Assert.NotNull(returnValue);
    }

    [Fact]
    public async Task GetRoles_ReturnsInternalServerError_OnException()
    {
        // Arrange
        _mockRoleService
            .Setup(service => service.GetAllRolesAsync())
            .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.GetRoles();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }
}
