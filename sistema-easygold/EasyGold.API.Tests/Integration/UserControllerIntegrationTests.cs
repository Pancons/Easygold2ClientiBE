using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Tests.Integration
{
    public class UserControllerIntegrationTests 
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UserControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetUsersList_NoAuth_ReturnsOk()
        {
            // Nel tuo UserController, /api/User/list NON ha [Authorize]
            // Quindi senza token dovrebbe rispondere 200 OK
            var filter = new { /* campi di UserFilterDTO se vuoi */ };
            var resp = await _client.PostAsJsonAsync("/api/User/list", filter);

            resp.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact]
        public async Task AddUser_WithToken_ReturnsCreated()
        {
            // /api/User (POST) è protetto da [Authorize]
            var token = await GetTestToken();
            _client.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue("Bearer", token);

            var newUser = new 
            {
                Ute_IDUtente = 999,
                Ute_Nome = "Mario",
                Ute_Cognome = "Rossi",
                Ute_NomeUtente = "mario.rossi",
                Ute_IDRuolo = 1
            };

            var resp = await _client.PostAsJsonAsync("/api/User", newUser);
            resp.EnsureSuccessStatusCode();
            // L'endpoint dice che restituisce CreatedAtAction => 201
            Assert.Equal(HttpStatusCode.Created, resp.StatusCode);
        }

        private async Task<string> GetTestToken()
        {
            var login = new { Username = "testUser", Password = "testPass" };
            var response = await _client.PostAsJsonAsync("/api/Auth/login", login);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = System.Text.Json.JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("token").GetString();
        }
    }
}
