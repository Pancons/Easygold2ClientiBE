using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EasyGold.Web2.Models.Cliente.Entities
{
    [Table("tbcl_causali")]
    public class DbCausaliCliente : BaseDbEntity
    {
        [Key]
        public int Cal_IDAuto { get; set; }

        [Required, StringLength(100)]
        public string Cal_Descrizione { get; set; }

        [Required]
        public int Cal_IDDoveUso { get; set; }

        [Required]
        public int Cal_IDProgressivo { get; set; }

        [Required]
        public int Cal_IDtipoAnagrafica { get; set; }

        [Required]
        public int Cal_IDtipoIVA { get; set; }

        public bool Cal_Annulla { get; set; }
    }
}