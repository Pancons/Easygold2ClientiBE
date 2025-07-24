using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Tabella “Cliente” dbo.tbcl_stampePostazioni
    /// Contiene i dati relativi alla gestione delle stampanti per ogni postazione abilitata.
    /// </summary>
    [Table("tbcl_stampePostazioni")]
    public class DbStampePostazioni
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// Identificativo univoco del record di stampa per postazione.
        /// </summary>
        [Key]
        public int Tpo_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il campo tpo_IDAuto della tabella dbo.tbcl_testataPostazioni.
        /// Rappresenta la postazione associata.
        /// </summary>
        public int Tpo_IDPostazione { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il campo mst_IDAuto della tabella dbo.tbco_moduliStampe.
        /// Identifica il modulo di stampa associato alla postazione.
        /// </summary>
        public int Tpo_IDStampa { get; set; }

        /// <summary>
        /// Campo Alfa 50 Caratteri.
        /// Indica l’IP del device dove deve stampare il documento generato.
        /// </summary>
        [StringLength(50)]
        public string Tpo_IPDevice { get; set; }

        /// <summary>
        /// Campo Alfa 100 Caratteri.
        /// Nome del device dove stampare il documento.
        /// Nella form è una combo con ricerca alimentata da un'API che interroga il programma di stampa sul device.
        /// </summary>
        [StringLength(100)]
        public string Tpo_Device { get; set; }

        /// <summary>
        /// Campo Bit.
        /// Se a True la stampa viene inviata direttamente alla stampante configurata.
        /// Se False viene mostrata un’anteprima di stampa all’utente.
        /// </summary>
        public bool Tpo_Diretta { get; set; }

        /// <summary>
        /// Campo Bit.
        /// Se a True il record non è attivo.
        /// </summary>
        public bool Tpo_Annullato { get; set; }

        /// <summary>
        /// Chiave esterna verso la tabella delle Testate Postazioni.
        /// </summary>
        [ForeignKey("Tpo_IDPostazione")]
        public virtual DbTestataPostazioni TestataPostazioni { get; set; }

        /// <summary>
        /// Chiave esterna verso la tabella dei Moduli di Stampa.
        /// </summary>
        [ForeignKey("Tpo_IDStampa")]
        public virtual DbModuliStampe ModuliStampe { get; set; }
    }
}
