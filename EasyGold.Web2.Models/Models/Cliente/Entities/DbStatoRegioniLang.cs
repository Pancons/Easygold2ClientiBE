using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EasyGold.Web2.Models.Cliente.Entities
{
    [Table("StatoRegioni")]
    public class DbStatoRegioniLang
    {
        [Key]
        [Column("StrIdISONum")]
        public int StridISONum { get; set; }

        [Column("StrIdID")]
        public int StridID { get; set; }

        [Column("StrDescrizione")]
        public string StridDescrizione { get; set; }
    }
}



// ... rest of code ...