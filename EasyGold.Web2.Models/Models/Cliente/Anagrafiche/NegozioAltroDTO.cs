using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.Anagrafiche
{
    public class NegozioAltroDTO
    {
        public int Id { get; set; }
        public int NazioneId { get; set; }
        public int ValutaId { get; set; }
        public int ListinoId { get; set; }
        public int AliquotaIVAId { get; set; }
    }
}