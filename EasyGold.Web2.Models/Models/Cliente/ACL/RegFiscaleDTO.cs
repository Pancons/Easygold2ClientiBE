using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class RegFiscaleDTO
    {
        [SwaggerSchema(Description = "ID Automatico.")]
        public int Rfi_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del Registratore Fiscale.")]
        [StringLength(50)]
        public string Rfi_Descrizione { get; set; }

        [SwaggerSchema(Description = "Tipo del Registratore Fiscale.")]
        public int Rfi_TipoRegFiscale { get; set; }

        [SwaggerSchema(Description = "Codice del Negozio Associato.")]
        public int Rfi_CodNegozio { get; set; }

        [SwaggerSchema(Description = "Matricola del Registratore Fiscale.")]
        [StringLength(50)]
        public string Rfi_Matricola { get; set; }

        [SwaggerSchema(Description = "Numero delle chiusure effettuate.")]
        public int Rfi_NumeroChiusure { get; set; }

        [SwaggerSchema(Description = "Data e ora dell'ultima chiusura.")]
        public DateTime Rfi_UltimaDataChiusura { get; set; }

        [SwaggerSchema(Description = "Indica se il registratore fiscale non è più disponibile.")]
        public bool Rfi_Annullato { get; set; }
    }
}