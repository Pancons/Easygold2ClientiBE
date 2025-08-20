using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    /// <summary>
    /// DTO per Province.
    /// </summary>
    public class ProvinceDTO
    {
        [SwaggerSchema(Description = "Numero ISO 3166 1 della Nazione.")]
        public int Str_ISO1 { get; set; }

        [SwaggerSchema(Description = "Codice della Provincia.")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "Nome della Provincia.")]
        [StringLength(200)]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "Sigla della Provincia sulla targa dell'automobile.")]
        [StringLength(20)]
        public string Str_SiglaTargaAuto { get; set; }

        [SwaggerSchema(Description = "Codice dello Stato/Regione a cui appartiene la Provincia.")]
        public int Str_CodStatoRegione { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni per la provincia.")]
        public List<ProvinceLangDTO> Traduzioni { get; set; } = new List<ProvinceLangDTO>();
    }
}