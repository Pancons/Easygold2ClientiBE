using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.Variabili
{

    // DTO per tbco_ValoriTabelle
    public class ValoriTabelleDTO
    {
        public int? RowId { get; set; }
        public string LstDescription { get; set; }
        public string? LstItemType { get; set; }
    }
}