using Swashbuckle.AspNetCore.Annotations;
using  EasyGold.API.Models.Entities;

namespace EasyGold.API.Models.Clienti
{
    public class ClienteRecord
    {
        public DbCliente Cliente { get; set; }
        public DbDatiCliente? DatiCliente { get; set; }
    }
}