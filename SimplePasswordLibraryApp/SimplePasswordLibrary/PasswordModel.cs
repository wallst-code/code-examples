using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordLibrary
{
    public class PasswordModel
    {
        public string seedPassword { get; set; }
        public string siteName { get; set; }
        public string myKey { get; set; }
        public int pinNumber { get; set; }
    }
}
