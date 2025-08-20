using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL.Requests
{

    public class ResetPasswordRequest
        {
            [Required]
            public string Token { get; set; }

            [Required]
            public string NewPassword { get; set; }
        }
}