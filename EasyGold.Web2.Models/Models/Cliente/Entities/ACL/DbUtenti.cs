using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_utenti")]
    public class DbUtenti : BaseDbEntity
    {
        [Key]
        public int Ute_IDAuto { get; set; }
        [Required, StringLength(30)]
        public string Ute_IDUtente { get; set; }
        [Required, StringLength(100)]
        public string Ute_NomeUtente { get; set; }

        [Required]
        public int Ute_IDGruppo { get; set; }

        [Required]
        public int Ute_IDIdioma { get; set; }

        public bool Ute_AbilitaTuttiNegozi { get; set; }
        public bool Ute_AbilitaCassa { get; set; }
        public bool Ute_AbilitaEliminaProd { get; set; }
        public bool Ute_Bloccato { get; set; }
    }
}