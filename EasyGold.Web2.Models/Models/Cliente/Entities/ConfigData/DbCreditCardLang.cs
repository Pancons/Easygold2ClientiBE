using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{
    public class DbCreditCardLang : BaseDbEntity
    {
        [Required]
        public int Crcid_ISONum { get; set; }

        [Required]
        public int Crcid_ID { get; set; }

        [StringLength(100)]
        public string? Crcid_Brand { get; set; }
    }
}
