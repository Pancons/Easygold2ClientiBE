using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.API.Models.Clients
{
    public class ClienteListResult
    {
        [SwaggerSchema(Description = "Elenco dei clienti")]
        public IEnumerable<ClienteDTO> Clienti { get; set; }

        [SwaggerSchema(Description = "Numero totale di clienti")]
        public int Total { get; set; }
    }
}
