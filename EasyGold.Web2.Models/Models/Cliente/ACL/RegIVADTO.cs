using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class RegIVADTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto. È il codice del registro IVA.")]
        public int RowIdAuto { get; set; }

        [SwaggerSchema(Description = "Campo Testo 50 caratteri. È la descrizione del Registro IVA.")]
        [StringLength(50)]
        public string RgiDescrizione { get; set; }

        [SwaggerSchema(Description = "Campo Testo 10 caratteri. È il prefisso che verrà aggiunto prima del numero della fattura.")]
        [StringLength(10)]
        public string RgiPrefisso { get; set; }

        [SwaggerSchema(Description = "Campo Testo 10 caratteri. È il suffisso che verrà aggiunto dopo del numero della fattura.")]
        [StringLength(10)]
        public string RgiSuffisso { get; set; }

        [SwaggerSchema(Description = "Campo Bit. Indica se il registro IVA è annullato.")]
        public bool RgiAnnulla { get; set; }

        [SwaggerSchema(Description = "Lista dei numeri del registro IVA associati.")]
        public List<NumeriRegIVADTO> NumeriRegIVA { get; set; } = new List<NumeriRegIVADTO>();
    }
}