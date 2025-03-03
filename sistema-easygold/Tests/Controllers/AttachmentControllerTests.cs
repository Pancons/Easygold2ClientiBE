
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AttachmentControllerTests
{
    [Fact]
    public async Task GetAttachments_ReturnsOkResult_WithListOfAttachments()
    {
        // Arrange
        var mockService = new Mock<IAttachmentService>();
        mockService.Setup(service => service.GetAttachmentsAsync())
                   .ReturnsAsync(new List<AllegatoDTO> { new AllegatoDTO { All_IDAllegato = 1, All_NomeFile = "file.txt" } });
        var controller = new AttachmentController(mockService.Object);

        // Act
        var result = await controller.GetAttachments();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var attachments = Assert.IsType<List<AllegatoDTO>>(okResult.Value);
        Assert.Single(attachments);
    }
}
