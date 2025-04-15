using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Tests.Integration
{
    public class AuthControllerIntegrationTests 
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsToken()
        {
            var login = new { Username = "testUser", Password = "testPass" };

            var response = await _client.PostAsJsonAsync("/api/Auth/login", login);

            // Se credenziali valide => 200
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            Assert.Contains("token", json);
        }

        [Fact]
        public async Task Login_InvalidCredentials_Returns401()
        {
            var login = new { Username = "wrongUser", Password = "wrongPass" };

            var response = await _client.PostAsJsonAsync("/api/Auth/login", login);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
