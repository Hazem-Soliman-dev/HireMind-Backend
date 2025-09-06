using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMind.Application.DTO
{
    public class TokenRequestModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
