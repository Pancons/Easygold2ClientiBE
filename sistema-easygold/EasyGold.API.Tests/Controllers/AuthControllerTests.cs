using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EasyGold.API.Services.Interfaces;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Users;
using EasyGold.API.Models.Entities;

public class AuthControllerTests
{
    [Fact]
    public async Task Login_ReturnsOkResult()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var mockConfiguration = new Mock<IConfiguration>();

        var fakeUser = new DbUtente
        {
            Ute_IDUtente = 1,
            Ute_NomeUtente = "testUser",
            Ute_IDRuolo = 2
        };

        mockUserService
            .Setup(s => s.AuthenticateAsync("testUser", "testPassword"))
            .ReturnsAsync(fakeUser);

        mockConfiguration
            .Setup(c => c["Jwt:Secret"])
            .Returns("LaMiaChiaveSegretaSuperLungaDiAlmeno32Caratteri");

        var controller = new AuthController(mockUserService.Object, mockConfiguration.Object);

        var request = new EasyGold.API.Controllers.AuthController.LoginRequest
        {
            Username = "testUser",
            Password = "testPassword"
        };

        // Act
        var result = await controller.Login(request);

        // Debug: stampa il tipo di risultato per capire il problema
        Console.WriteLine($"Tipo di risultato: {result.GetType().Name}");

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Console.WriteLine($"Codice HTTP restituito: {objectResult.StatusCode}");

        Assert.Equal(200, objectResult.StatusCode);
    }


}
