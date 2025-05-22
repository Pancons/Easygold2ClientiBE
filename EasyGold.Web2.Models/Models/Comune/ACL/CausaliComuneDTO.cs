using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class CausaliComuneDTO
    {
        public int Cac_IDAuto { get; set; }
        [StringLength(100)]
        public string Cac_Descrizione { get; set; }
        public int Cac_IDDoveUso { get; set; }
        public int Cac_IDProgressivo { get; set; }
        public int Cac_IDtipoAnagrafica { get; set; }
        public int Cac_IDtipoIVA { get; set; }
        public bool Cac_Annulla { get; set; }
    }
}