using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Anagrafiche
{
    /// <summary>
    /// Tabella “Cliente” dbo.tbcl_nazioneNegozio
    /// Rappresenta valori configurabili per negozi su base nazionale e per tipo di campo.
    /// </summary>
    [Table("tbcl_nazioneNegozio")]
    public class DbNazioneNegozio : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// Identificativo univoco del record.
        /// </summary>
        [Key]
        public int Nne_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero Obbligatorio.
        /// Identificativo del negozio a cui è riferito il valore.
        /// </summary>
        [Required]
        public int Nne_IDNegozio { get; set; }

        /// <summary>
        /// Campo Numerico Intero Obbligatorio.
        /// Identifica il tipo di campo configurato per il negozio (es. codice ISO, campo custom...).
        /// </summary>
        [Required]
        public int Nne_IDTipoCampo { get; set; }

        /// <summary>
        /// Campo Alfa 200 Caratteri.
        /// Valore associato al tipo di campo e al negozio.
        /// </summary>
        [StringLength(200)]
        public string? Nne_Valore { get; set; }
    }
}
