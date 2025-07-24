using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_testataPostazioni")]//
    public class DbTestataPostazioni : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto
        /// </summary>
        [Key]
        public int tpo_IDAuto { get; set; }

        /// <summary>
        /// Campo Alfa di 50 caratteri. È la descrizione della postazione.
        /// </summary>
        [StringLength(50)]
        public string tpo_descizione { get; set; }

        /// <summary>
        /// Campo Bit. Se a True la postazione ha accesso al Registratore Fiscale. È selezionata a True in automatico quando viene inserito un record sulla tabella relativa. Deve essere riportato a False se poi il record in tabella viene cancellato.
        /// </summary>
        public bool tpo_registratore { get; set; }

        /// <summary>
        /// Campo Bit. Se a True la postazione ha accesso alle Stampanti. È selezionata a True in automatico quando viene inserito un record sulla tabella relativa. Deve essere riportato a False se poi il record in tabella viene cancellato.
        /// </summary>
        public bool tpo_stampanti { get; set; }

        /// <summary>
        /// Campo Bit. Se a True la postazione ha accesso al lettore di card. È selezionata a True in automatico quando viene inserito un record sulla tabella relativa. Deve essere riportato a False se poi il record in tabella viene cancellato.
        /// </summary>
        public bool tpo_card { get; set; }

        /// <summary>
        /// Campo Bit. Se a True l’Utente NON ha più accesso alla postazione.
        /// </summary>
        public bool tpo_annullato { get; set; }

          
        public List<DbStampePostazioni> StampePostazioni { get; set; } = new List<DbStampePostazioni>();

       
        public List<DbFiscalePostazioni> FiscalePostazioni { get; set; } = new List<DbFiscalePostazioni>();

       
        public List<DbLettorePostazioni> LettorePostazioni { get; set; } = new List<DbLettorePostazioni>();

    }
}