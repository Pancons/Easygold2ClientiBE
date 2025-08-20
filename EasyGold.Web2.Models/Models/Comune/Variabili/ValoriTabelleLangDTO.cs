using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.Variabili
{
    // DTO per tbco_ValoriTabelleLang
    public class ValoriTabelleLangDTO
    {
        public int? RowId { get; set; }
        public int LstlItemId { get; set; }
        public int LstlLanguageId { get; set; }
        public string LstlDescription { get; set; }
    }
}