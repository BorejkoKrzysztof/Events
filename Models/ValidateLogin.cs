using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models
{
    public class ValidateLogin
    {
        public string email { get; set; }
        public string password { get; set; }
        public string returnUrl { get; set; }
    }
}
