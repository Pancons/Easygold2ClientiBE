using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Services.Implementations; // o il namespace esatto dove sta AllegatoService
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Allegati;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Services.Interfaces;

public class AllegatoControllerTests
{
    [Fact]
    public async Task GetAllAttachments_ReturnsOkResult()
    {
        // 1) Creiamo un mock di AllegatoService.
        //    Se AllegatoService richiede costruttori con parametri, crea/sostituisci i mock opportuni
        var mockAllegatoService = new Mock<IAllegatoService>();

        // 2) Impostiamo una simulazione per GetAllAsync().
        mockAllegatoService
            .Setup(s => s.GetAllAsync()).ReturnsAsync(new List<AllegatoDTO>()); // ad esempio una lista vuota

        // 3) Creiamo il controller iniettando l'oggetto mockato.
        var controller = new AllegatoController(mockAllegatoService.Object);

        // 4) Chiamiamo il metodo esistente GetAllAttachments() (non GetAllegati())
        var result = await controller.GetAllAttachments();

        // 5) Verifichiamo che il result sia un OkObjectResult
        Assert.IsType<OkObjectResult>(result);

        // (Opzionale) Controlliamo che GetAllAsync() sia stato invocato
        mockAllegatoService.Verify(s => s.GetAllAsync(), Times.Once);
    }
}
