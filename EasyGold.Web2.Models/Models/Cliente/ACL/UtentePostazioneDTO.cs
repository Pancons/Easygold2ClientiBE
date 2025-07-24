using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class UtentePostazioneDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale della postazione.")]
        public int Upo_IDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il campo neg_IDAuto della tabella dbo.tbcl_negozi. Nella Form è un campo Combo a Selezione Singola con Ricerca. Deve visualizzare i valori della tabella dbo.tbcl_negozi.")]
        public int Upo_IdUtente_IDNegozio { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il campo pos_IDAuto della tabella dbo.tbcl_postazioni. Nella Form è un campo Combo a Selezione Singola con Ricerca. Deve visualizzare i valori della tabella dbo.tbcl_postazioni.")]
        public int Upo_IDPostazione { get; set; }

        [SwaggerSchema(Description = "Campo Bit. Se a True l’Utente NON ha più accesso al Negozio.")]
        public bool Upo_Annullato { get; set; }

        /*[SwaggerSchema(Description = "Descrizione della postazione.")]
        [StringLength(100)]
        public string Post_Descrizione { get; set; }*/
    }
}