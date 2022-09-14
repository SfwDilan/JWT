using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //webapi>appsetting.json'daki security key'i buraya gönderip byte array formatına dönüştürüyoruz.ve bir key' e dönüştürüyoruz(simetrik,asimetrik....)
        //microsoft.IdentityModel.tokens packages indirildi.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
