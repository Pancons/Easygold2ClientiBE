
using Xunit;
using Moq;
using EasyGold.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class AttachmentControllerTests
{
    [Fact]
    public async void GetAttachments_ReturnsOkResult()
    {
        // Arrange
        var controller = new AttachmentController();

        // Act
        var result = await controller.GetAttachments();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
