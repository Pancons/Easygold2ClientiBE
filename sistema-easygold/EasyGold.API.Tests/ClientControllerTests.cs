using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Features.Clients.Queries;
using ClientDto = EasyGold.API.Models.Clients.ClientDto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EasyGold.API.Tests
{
    public class ClientControllerTests
    {
        [Fact]
        public async Task ListClients_ReturnsOkResult_WithListOfClients()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetClientsQuery>(), default))
                        .ReturnsAsync(new List<ClientDto>());

            var controller = new ClientController(mediatorMock.Object);

            // Act
            var result = await controller.ListClients();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ClientDto>>(okResult.Value);
            Assert.Empty(returnValue);
        }
    }
}
