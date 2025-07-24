using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_PermessiGruppo")]//
    public class DbPermessiGruppo : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto
        /// </summary>
        [Key]
        public int Abg_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo grp_IDAuto della tabella dbo.tbcl_gruppi.
        /// </summary>
        public int Abg_IDGruppo { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo abl_IDAuto della tabella dbo.tbco_funzioni a cui si vuole attribuire una abilitazione. L’abilitazione scelta sarà inserita automaticamente da Easygold alla voce selezionata e a tutte quelle sotto.
        /// </summary>
        public int Abg_IDFunzione { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il valore del campo tpa_IDAuto della tabella dbo.tbco_tipoPermesso. Nella form è un campo Combo a Scelta Singola con ricerca della tabella dbo.tbco_tipoPermesso.
        /// </summary>
        public int Abg_IDTipoPermesso { get; set; }

        

        public virtual DbGruppi Gruppi { get; set; } = new DbGruppi();
        public virtual DbFunzioni Funzioni { get; set; } = new DbFunzioni();
        public virtual DbTipoPermesso DbTipoPermesso { get; set; } = new DbTipoPermesso();
        
    }
}