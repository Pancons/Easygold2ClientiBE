using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ConfigData
{
    public class CausaliClienteDTO
    {
        public int Cal_IDAuto { get; set; }
        [StringLength(100)]
        public string Cal_Descrizione { get; set; }
        public int Cal_IDDoveUso { get; set; }
        public int Cal_IDProgressivo { get; set; }
        public int Cal_IDtipoAnagrafica { get; set; }
        public int Cal_IDtipoIVA { get; set; }
        public bool Cal_Annulla { get; set; }
    }
}