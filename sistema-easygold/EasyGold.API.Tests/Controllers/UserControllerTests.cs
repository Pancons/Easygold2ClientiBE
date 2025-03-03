using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EasyGold.API.Controllers;
using EasyGold.API.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyGold.API.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<ApplicationDbContext> _mockContext;

        public UserControllerTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _controller = new UserController(_mockContext.Object);
        }

        [Fact]
        public async Task ListUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var request = new UserListRequest
            {
                Filters = new Dictionary<string, string>(),
                Offset = 0,
                Limit = 10,
                Sort = new List<SortOption>()
            };

            // Act
            var result = await _controller.ListUsers(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var users = Assert.IsAssignableFrom<IEnumerable<UserDto>>(okResult.Value);
            Assert.NotNull(users);
        }

        [Fact]
        public async Task GetUser_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Act
            var result = await _controller.GetUser(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task UpdateUser_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var user = new UserDetailDto { Id = 999, Nome = "Nonexistent User" };

            // Act
            var result = await _controller.UpdateUser(user);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
