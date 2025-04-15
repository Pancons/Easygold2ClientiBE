using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;


namespace EasyGold.API.Tests.Integration
{
    public class AllegatoControllerIntegrationTests 
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AllegatoControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            // Usa il DB reale definito in appsettings.json
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllAttachments_WithoutToken_Returns401()
        {
            // Endpoint protetto, mi aspetto 401 se non passo token
            var response = await _client.GetAsync("/api/Allegato");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetAllAttachments_WithToken_ReturnsOk()
        {
            // Ottengo un token valido
            var token = await GetTestToken();

            // Aggiungo Authorization: Bearer {token}
            _client.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.GetAsync("/api/Allegato");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddAttachment_WithToken_ReturnsCreated()
        {
            var token = await GetTestToken();
            _client.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue("Bearer", token);

            // Dati di test
            var allegato = new 
            {
                All_IDAllegato = 9999,
                All_NomeFile = "fileTest.pdf",
                All_Estensione = "pdf",
                All_Dimensione = 1234,
                All_EntitaRiferimento = "Test",
                All_RecordId = 1
            };

            var response = await _client.PostAsJsonAsync("/api/Allegato", allegato);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        // ... Altri test: GetAttachment(id), UpdateAttachment, DeleteAttachment, ecc.

        /// <summary>Ottiene un token JWT chiamando /api/Auth/login</summary>
        private async Task<string> GetTestToken()
        {
            var credentials = new { Username = "testUser", Password = "testPass" };
            var resp = await _client.PostAsJsonAsync("/api/Auth/login", credentials);

            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();

            using var doc = System.Text.Json.JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("token").GetString();
        }
    }
}
