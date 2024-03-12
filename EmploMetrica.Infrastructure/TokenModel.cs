using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Infrastructure
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
    public class AccessToken
    {
        public string AccessTokenValue { get; set; }
    }
    public class RefreshToken
    {
        public string RefreshTokenValue { get; set; }
    }
}
