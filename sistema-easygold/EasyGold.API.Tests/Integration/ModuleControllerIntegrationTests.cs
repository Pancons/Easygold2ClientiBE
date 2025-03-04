using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Tests.Integration
{
    public class ModuleControllerIntegrationTests 
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ModuleControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetModulesDropdown_WithoutToken_Returns401()
        {
            // /api/Module/dropdown è protetto da [Authorize], 
            // quindi senza token => 401
            var resp = await _client.GetAsync("/api/Module/dropdown");
            Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
        }

        [Fact]
        public async Task GetModulesDropdown_WithToken_ReturnsOk()
        {
            var token = await GetTestToken();
            _client.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue("Bearer", token);

            var resp = await _client.GetAsync("/api/Module/dropdown");
            resp.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
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
