using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMind.Infrastructure.Service
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; } 
        public string Audience { get; set; }
        public double ExpiryInMinutes { get; set; }
    }
}
