using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.Web2.Models.Cliente.Entities.Anagrafiche
{
    /// <summary>
    /// Tabella dbo.tbco_nazioneFisco
    /// Contiene dati relativi ai campi fiscali richiesti dalla normativa della Nazione.
    /// </summary>
    [Table("tbco_nazioneFisco")]
    public class DbNazioneFisco
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Nfs_IDAuto { get; set; }

        /// <summary>
        /// Codice della Nazione. È il campo ntn_ISO1 della tabella dbo.tbco_ISONazioni.
        /// </summary>
        public int Nfs_IDNazione { get; set; }
        
        /// <summary>
        /// Descrizione del campo richiesto dalla normativa fiscale.
        /// </summary>
        [StringLength(100)]
        public string Nfs_Descrizione { get; set; }

        /// <summary>
        /// Tipo di campo. (0=Alfa, 1=Numerico Intero, 2=Numerico Decimale, 3=Money, 4=Campo di Ricerca)
        /// </summary>
        public int Nfs_TipoCampo { get; set; }

        /// <summary>
        /// Se True, il campo è obbligatorio per la memorizzazione dei dati.
        /// </summary>
        public bool Nfs_Obbligatorio { get; set; }
    }
}