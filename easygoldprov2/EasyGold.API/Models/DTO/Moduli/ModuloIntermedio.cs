using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.DTO.Moduli
{
    public class ModuloIntermedio
    {
        public int Mde_IDAuto { get; set; }
        public string Mde_CodEcomm { get; set; }
        public string Mde_Descrizione { get; set; }
        public string Mde_DescrizioneEstesa { get; set; }
        public int Mdc_IDAuto { get; set; }
        public int Mdc_IDCliente { get; set; }
        public int Mdc_IDModulo { get; set; }
        public DateTime? Mdc_DataAttivazione { get; set; }
        public DateTime? Mdc_DataDisattivazione { get; set; }
        public bool Mdc_BloccoModulo { get; set; }
        public DateTime? Mdc_DataOraBlocco { get; set; }
        public string Mdc_Nota { get; set; }
    }

}