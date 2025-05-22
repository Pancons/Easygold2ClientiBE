using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
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