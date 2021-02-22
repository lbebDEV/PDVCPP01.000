using PDVCPP01._000.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.HttpClients
{
    public class LoginHttpClient : HttpClientBase<Login>
    {
        public LoginHttpClient(string url) : base(url)
        {

        }
    }
}
