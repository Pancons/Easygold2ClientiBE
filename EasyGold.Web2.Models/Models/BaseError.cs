using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models
{
    public class BaseError  
    {   
        public string Message { get; set; }
        public string Code { get; set; }

        public BaseError() { }

        public BaseError(string message, string code)
        {
            Message = message;
            Code = code;
        }
    }
    
}