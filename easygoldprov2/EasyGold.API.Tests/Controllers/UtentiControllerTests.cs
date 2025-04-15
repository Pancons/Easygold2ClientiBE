
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Services.Interfaces;
public class UtentiControllerTests
{
    private readonly Mock<IUtenteService> _mockUtenteService;
    private readonly UtentiController _controller;

    public UtentiControllerTests()
    {
        _mockUtenteService = new Mock<IUtenteService>();
        _controller = new UtentiController(_mockUtenteService.Object);
    }

    [Fact]
    public async Task GetUsersList_ReturnsOkResult_WithUsers()
    {
        // Arrange
        var filter = new UserFilterDTO();
        var users = new List<UtenteDTO> { new UtenteDTO { Ute_IDUtente = 1, Ute_Nome = "Test User" } };
        _mockUtenteService.Setup(service => service.GetUsersListAsync(filter))
                          .ReturnsAsync((users, users.Count));

        // Act
        var result = await _controller.GetUsersList(filter);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task GetUsersList_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var filter = new UserFilterDTO();
        _mockUtenteService.Setup(service => service.GetUsersListAsync(filter))
                          .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.GetUsersList(filter);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task AddUser_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var userDto = new UtenteDTO { Ute_IDUtente = 1, Ute_Nome = "New User" };
        _mockUtenteService.Setup(service => service.AddAsync(userDto))
                          .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.AddUser(userDto);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetUser), createdAtActionResult.ActionName);
        Assert.Equal(userDto, createdAtActionResult.Value);
    }

    [Fact]
    public async Task AddUser_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var userDto = new UtenteDTO { Ute_IDUtente = 1, Ute_Nome = "New User" };
        _controller.ModelState.AddModelError("error", "some error");

        // Act
        var result = await _controller.AddUser(userDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task AddUser_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var userDto = new UtenteDTO { Ute_IDUtente = 1, Ute_Nome = "New User" };
        _mockUtenteService.Setup(service => service.AddAsync(userDto))
                          .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.AddUser(userDto);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task UpdateUser_ReturnsNoContent()
    {
        // Arrange
        var userDto = new UtenteDTO { Ute_IDUtente = 1, Ute_Nome = "Updated User" };
        _mockUtenteService.Setup(service => service.UpdateAsync(userDto))
                          .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateUser(userDto.Ute_IDUtente, userDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateUser_ReturnsBadRequest_WhenIdMismatch()
    {
        // Arrange
        var userDto = new UtenteDTO { Ute_IDUtente = 1, Ute_Nome = "Updated User" };

        // Act
        var result = await _controller.UpdateUser(2, userDto);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task UpdateUser_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var userDto = new UtenteDTO { Ute_IDUtente = 1, Ute_Nome = "Updated User" };
        _mockUtenteService.Setup(service => service.UpdateAsync(userDto))
                          .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.UpdateUser(userDto.Ute_IDUtente, userDto);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task GetUser_ReturnsOkResult_WithUser()
    {
        // Arrange
        var userId = 1;
        var user = new UtenteDTO { Ute_IDUtente = userId, Ute_Nome = "Existing User" };
        _mockUtenteService.Setup(service => service.GetUserByIdAsync(userId))
                          .ReturnsAsync(user);

        // Act
        var result = await _controller.GetUser(userId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        dynamic returnValue = okResult.Value;
        Assert.NotNull(returnValue);
    }

    [Fact]
    public async Task GetUser_ReturnsNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = 1;
        _mockUtenteService.Setup(service => service.GetUserByIdAsync(userId))
                          .ReturnsAsync((UtenteDTO)null);

        // Act
        var result = await _controller.GetUser(userId);

        // Assert
       Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task GetUser_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var userId = 1;
        _mockUtenteService.Setup(service => service.GetUserByIdAsync(userId))
                          .ThrowsAsync(new System.Exception("Test exception"));

        // Act
        var result = await _controller.GetUser(userId);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }
}
