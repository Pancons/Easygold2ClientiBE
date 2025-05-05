
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using EasyGold.API.Models.Variabili;

namespace EasyGold.API.Services.Clients
{
    public class ValoriTabelleApiClient
    {
        private readonly HttpClient _httpClient;

        public ValoriTabelleApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<bool> LoginAsync()
        {
            var loginData = new { username = "admin", password = "Abcd1234@" };
            var response = await _httpClient.PostAsJsonAsync("/api/Autenticazione/login", loginData);
            if (!response.IsSuccessStatusCode) return false;

            using var contentStream = await response.Content.ReadAsStreamAsync();
            using var json = await JsonDocument.ParseAsync(contentStream);
            var token = json.RootElement.GetProperty("token").GetString();

            Console.WriteLine("QUAAAAAAAAA");
            Console.WriteLine(token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return true;
        }

        public async Task<IEnumerable<ValoriTabelleDTO>> List(string lstItemType)
        {

            var loggedIn = await LoginAsync();
            if (!loggedIn) throw new Exception("Login fallito");
            var response = await _httpClient.PostAsJsonAsync("/api/ValoriTabelle/list", new { lstItemType });
            response.EnsureSuccessStatusCode();

            // Classe interna per mappare la risposta
            var wrapper = await response.Content.ReadFromJsonAsync<ValoriTabelleListResponse>();
            return wrapper?.results ?? new List<ValoriTabelleDTO>();
        }

        public async Task<ValoriTabelleDTO> Save(ValoriTabelleDTO dto)
        {
            var loggedIn = await LoginAsync();
            if (!loggedIn) throw new Exception("Login fallito");

            var response = await _httpClient.PostAsJsonAsync("/api/ValoriTabelle/save", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ValoriTabelleDTO>();
        }

        public async Task Delete(int id)
        {
            var loggedIn = await LoginAsync();
            if (!loggedIn) throw new Exception("Login fallito");

            var response = await _httpClient.DeleteAsync($"/api/ValoriTabelle/{id}");
            response.EnsureSuccessStatusCode();
        }

        private class TokenResponse
        {
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; }
        }

        // Classe interna direttamente nel file
        private class ValoriTabelleListResponse
        {
            public List<ValoriTabelleDTO> results { get; set; }
            public int total { get; set; }
        }

    }
}
