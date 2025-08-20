using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class CausaliDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto per l'ID della causale.")]
        public int Cal_IDAuto { get; set; } // Usa "Cal_" per la tabella Cliente

        [SwaggerSchema(Description = "Descrizione della Causale.")]
        [StringLength(100)]
        public string Cal_Descrizione { get; set; }

        [SwaggerSchema(Description = "ID dell'uso della causale.")]
        public int Cal_IDDoveUso { get; set; }

        [SwaggerSchema(Description = "ID del progressivo associato.")]
        public int Cal_IDProgressivo { get; set; }

        [SwaggerSchema(Description = "ID del tipo di anagrafica.")]
        public int Cal_IDtipoAnagrafica { get; set; }

        [SwaggerSchema(Description = "ID del tipo di IVA.")]
        public int Cal_IDtipoIVA { get; set; }

        [SwaggerSchema(Description = "Se la causale è annullata.")]
        public bool Cal_Annulla { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni associate alla causale.")]
        public List<CausaliLangDTO> CausaliLang { get; set; } = new List<CausaliLangDTO>();
    }
}