using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Tests.Integration
{
    public class ClienteControllerIntegrationTests 
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ClienteControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task List_NoAuth_ReturnsOk()
        {
            var requestBody = new
            {
                Filters = new { DtcRagioneSociale = "Test" },
                Offset = 0,
                Limit = 10
            };

            var resp = await _client.PostAsJsonAsync("/api/Cliente/list", requestBody);
            resp.EnsureSuccessStatusCode(); 
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact]
        public async Task SaveClient_WithForm_ReturnsOk()
        {
            var formData = new MultipartFormDataContent
            {
                { new StringContent("Cliente di Test"), "Dtc_RagioneSociale" }
            };

            var resp = await _client.PostAsync("/api/Cliente/save", formData);
            resp.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact]
        public async Task GetClient_WithoutToken_ReturnsUnauthorized()
        {
            var resp = await _client.GetAsync("/api/Cliente/123"); 
            Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
        }

        [Fact]
        public async Task GetClient_WithToken_ReturnsOk_WhenClientExists()
        {
            var token = await GetTestToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = await _client.GetAsync("/api/Cliente/123");
            resp.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact]
        public async Task UpdateClient_WithFormData_ReturnsOk()
        {
            var formData = new MultipartFormDataContent
            {
                { new StringContent("5678"), "Utw_IDClienteAuto" },
                { new StringContent("Cliente Aggiornato"), "Dtc_RagioneSociale" }
            };

            var resp = await _client.PutAsync("/api/Cliente/update/5678", formData);
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
