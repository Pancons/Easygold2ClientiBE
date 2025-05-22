using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;


namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class AllegatoDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco dell'allegato")]
        public int? All_IDAllegato { get; set; }

        [Required]
        [StringLength(255)]
        [SwaggerSchema(Description = "Nome del file allegato")]
        public string All_NomeFile { get; set; }

        [Required]
        [StringLength(10)]
        [SwaggerSchema(Description = "Estensione del file allegato")]
        public string All_Estensione { get; set; }

        [Range(0, int.MaxValue)]
        [SwaggerSchema(Description = "Dimensione del file allegato in byte")]
        public int All_Dimensione { get; set; }

        [Required]
        [SwaggerSchema(Description = "Entità di riferimento dell'allegato")]
        public string All_EntitaRiferimento { get; set; }

        [SwaggerSchema(Description = "ID del record di riferimento dell'allegato")]
        public int All_RecordId { get; set; }

        [StringLength(500)]
        [SwaggerSchema(Description = "Note aggiuntive sull'allegato")]
        public string? All_Note { get; set; }

        [Url]
        [SwaggerSchema(Description = "URL dell'immagine allegata (solo lettura)")]
        public string? All_ImgUrl { get; private set; }

        [SwaggerSchema(Description = "Base64 del file da caricare")]
        public string? All_FileBase64 { private get; set; }

        public void SetImgUrl(string url)
        {
            All_ImgUrl = url;
        }
    }
}
