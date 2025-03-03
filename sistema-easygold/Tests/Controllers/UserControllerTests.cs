
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserControllerTests
{
    [Fact]
    public async Task GetUsers_ReturnsOkResult_WithListOfUsers()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService.Setup(service => service.GetUsersAsync())
                   .ReturnsAsync(new List<UtenteDTO> { new UtenteDTO { Utw_IDUtente = 1, Utw_Nome = "John" } });
        var controller = new UserController(mockService.Object);

        // Act
        var result = await controller.GetUsers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var users = Assert.IsType<List<UtenteDTO>>(okResult.Value);
        Assert.Single(users);
    }
}
