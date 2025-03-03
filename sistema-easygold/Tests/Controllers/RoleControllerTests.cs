
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoleControllerTests
{
    [Fact]
    public async Task GetRoles_ReturnsOkResult_WithListOfRoles()
    {
        // Arrange
        var mockService = new Mock<IRoleService>();
        mockService.Setup(service => service.GetRolesAsync())
                   .ReturnsAsync(new List<RuoloDTO> { new RuoloDTO { Ur_IDRuolo = 1, Ur_Descrizione = "Admin" } });
        var controller = new RoleController(mockService.Object);

        // Act
        var result = await controller.GetRoles();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var roles = Assert.IsType<List<RuoloDTO>>(okResult.Value);
        Assert.Single(roles);
    }
}
