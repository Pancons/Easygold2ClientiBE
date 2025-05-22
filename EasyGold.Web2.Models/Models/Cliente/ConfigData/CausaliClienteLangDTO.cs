using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;


namespace EasyGold.Web2.Models.Cliente.ConfigData
{
    public class CausaliClienteLangDTO
    {
        public int Cal_id_ISONum { get; set; }
        public int Cal_id_ID { get; set; }
        [StringLength(100)]
        public string Cal_id_Descrizione { get; set; }
    }
}