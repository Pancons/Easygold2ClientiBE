using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class NumeriRegIVADTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto. È il numero del record.")]
        public int RowIDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il codice del registro IVA presente nella tabella tb_cfgu_registriIVA.")]
        public int RowIDRegIVA { get; set; }

        [SwaggerSchema(Description = "Campo Data Anno. Determina la chiave di ricerca insieme al campo precedente rowIDRegIVA per determinare il numero della fattura da emettere.")]
        public int NriAnno { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il numero dell’ultima fattura emessa.")]
        public int NriNumFattura { get; set; }
    }
}