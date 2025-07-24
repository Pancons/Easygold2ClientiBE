using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGold.API.Utility
{
    public static class TokenUtility
    {
        public static string GenerateSecureToken()
        {
            using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[32];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
        
    }
}