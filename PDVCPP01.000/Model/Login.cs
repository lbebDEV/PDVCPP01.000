using PDVCPP01._000.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Login
    {
        public string login { get; set; } = Service_Config.Login;
        public string senha { get; set; } = Service_Config.Senha;
    }
}
