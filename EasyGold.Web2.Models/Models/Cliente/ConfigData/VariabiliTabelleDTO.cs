using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ConfigData
{

    // DTO per tbco_ValoriTabelle
    public class ValoriTabelleDTO
    {
        public int? RowId { get; set; }
        public string LstDescription { get; set; }
        public string? LstItemType { get; set; }
    }
}