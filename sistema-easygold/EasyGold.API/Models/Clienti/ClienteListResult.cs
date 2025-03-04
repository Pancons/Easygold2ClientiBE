using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.API.Models.Clienti
{
    public class ClienteListResult
    {
        [SwaggerSchema(Description = "Elenco dei clienti")]
        public IEnumerable<ClienteDTO> Clienti { get; set; }

        [SwaggerSchema(Description = "Numero totale di clienti")]
        public int Total { get; set; }
    }
}
