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
using EasyGold.API.Models.Utenti;
using EasyGold.API.Models.Entities;

public class AutenticazioneControllerTests
{
   [Fact]
    public async Task Login_ReturnsOkResult()
    {
        // Arrange
        var mockUserService = new Mock<IAutenticazioneService>();
        var mockConfiguration = new Mock<IConfiguration>();

        var fakeUser = new DbUtente
        {
            Ute_IDUtente = 1,
            Ute_NomeUtente = "testUser",
            Ute_IDRuolo = 2
        };

        // Simula la registrazione di un utente
        mockUserService
            .Setup(s => s.RegisterUserAsync("testUser", "testPassword", 2))
            .ReturnsAsync(true); // Simuliamo che la registrazione vada a buon fine

        // Simula l'autenticazione dell'utente appena registrato
        mockUserService
            .Setup(s => s.AuthenticateAsync("testUser", "testPassword"))
            .ReturnsAsync(fakeUser);

        mockConfiguration
            .Setup(c => c["Jwt:Secret"])
            .Returns("LaMiaChiaveSegretaSuperLungaDiAlmeno32Caratteri");

        var controller = new AutenticazioneController(mockUserService.Object, mockConfiguration.Object);

        var request = new EasyGold.API.Controllers.AutenticazioneController.LoginRequest
        {
            Username = "testUser",
            Password = "testPassword"
        };

        // **Precondizione: Registra l'utente prima della login**
        await mockUserService.Object.RegisterUserAsync("testUser", "testPassword", 2);

        // Act
        var result = await controller.Login(request);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
    }



}
