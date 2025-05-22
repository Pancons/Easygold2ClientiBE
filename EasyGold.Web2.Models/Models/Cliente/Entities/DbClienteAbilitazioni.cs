using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    [Table("tbcl_ClienteAbilitazioni")]
    public class DbClienteAbilitazioni : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto
        /// </summary>
        [Key]
        public int Abc_IDAuto { get; set; }
        /// <summary>
        /// È il campo abl_IDAuto della tabella dbo.tbco_abilitazioni a cui si vuole attribuire una abilitazione
        /// </summary>
        public int Abc_IDAbilitazione { get; set; }
        /// <summary>
        /// È il valore del campo tpa_IDAuto della tabella dbo.tbco_tipoPermesso.
        /// </summary>
        public int? Abc_LivelloAbilitazione { get; set; }
    }
}