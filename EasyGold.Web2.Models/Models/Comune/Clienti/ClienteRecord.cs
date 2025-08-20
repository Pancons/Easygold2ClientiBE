using Swashbuckle.AspNetCore.Annotations;
using EasyGold.Web2.Models.Comune.Entities.ACL;
//using  EasyGold.API.Models.Entities;

namespace EasyGold.Web2.Models.Comune.Clienti
{
    public class ClienteRecord
    {
        public DbCliente Cliente { get; set; }
        public DbModuloCliente? ModuliCliente { get; set; }
        /*public DbDatiCliente? DatiCliente { get; set; }
        */
    }
}