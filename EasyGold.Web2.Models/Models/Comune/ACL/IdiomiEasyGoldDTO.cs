using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class IdiomiEasyGoldDTO
    {
        [SwaggerSchema(Description = "ID Automatico dell'idioma.")]
        public int Idm_IDAuto { get; set; }

        [SwaggerSchema(Description = "Codice ISO numerico della lingua.")]
        public int Idm_ISONum { get; set; }
    }
}