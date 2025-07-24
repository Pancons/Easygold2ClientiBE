using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace  EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_refresh_token")]
    public class DbRefreshToken : BaseDbEntity
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsActive => DateTime.UtcNow < Expires;
        public string? Language { get; set; }
        public int? StoreId { get; set; }
        public int UserId { get; set; }
        public DbUtente User { get; set; }

        public void Revoke() => Expires = DateTime.UtcNow;
    }
}