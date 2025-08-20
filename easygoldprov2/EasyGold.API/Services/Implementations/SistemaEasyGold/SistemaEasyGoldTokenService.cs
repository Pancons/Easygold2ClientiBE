using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.SistemaEasyGold;

namespace EasyGold.API.Services.Implementations.SistemaEasyGold
{
    public class SistemaEasyGoldTokenService : ISistemaEasyGoldTokenService
{
    private readonly HttpClient _httpClient;
    private readonly string _loginUri = "http://sistemaeasygold.ddns.net/api/Autenticazione/login"; // Assicurati che il URL sia corretto
    private string _token;

    public SistemaEasyGoldTokenService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetTokenAsync()
    {
        if (string.IsNullOrEmpty(_token) || TokenIsExpired())
        {
            _token = await LoginAndGetTokenAsync("Admin", "Abcd1234@");
        }
        return _token;
    }

    private bool TokenIsExpired()
    {
        // Logica per verificare se il token è scaduto
        return false;
    }

    private async Task<string> LoginAndGetTokenAsync(string username, string password)
    {
        var loginRequest = new
        {
            username = username,
            password = password
        };

        var content = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_loginUri, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(responseContent);
            //return jsonResponse["token"]; // Adatta chiave se diversa
            string token = jsonResponse["token"].GetString();
            return token;
            //return tokenElement.GetString();
        }
        else
        {
            throw new Exception("Autenticazione fallita: " + response.ReasonPhrase);
        }
    }
}
}