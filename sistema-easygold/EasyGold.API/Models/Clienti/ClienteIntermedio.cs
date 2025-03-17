using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using EasyGold.API.Models.Entities; 

namespace EasyGold.API.Models.Clienti
{
    public class ClienteDettaglioIntermedio
    {
        public DbCliente Cliente { get; set; }
        public DbDatiCliente DatiCliente { get; set; }
        public List<DbModuloEasygold> Moduli { get; set; }
        public List<DbAllegato> Allegati { get; set; }
        public List<DbNegozi> Negozi { get; set; }
      

        public ClienteDettaglioIntermedio()
        {
            Cliente = new DbCliente();
            DatiCliente = new DbDatiCliente();
            Moduli = new List<DbModuloEasygold>();
            Allegati = new List<DbAllegato>();
            Negozi = new List<DbNegozi>();
        }
    }
}