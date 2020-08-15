using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMecanica.Dto
{
    public class LoginModel

    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public bool Recordarme { get; set; }
    }
}
