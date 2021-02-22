using Newtonsoft.Json;
using PDVCPP01._000.Config;
using PDVCPP01._000.DAO;
using PDVCPP01._000.HttpClients;
using PDVCPP01._000.Model;
using PDVCPP01._000.ServiceLog;
using PDVCPP01._001.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Controllers
{
    class TokenController : RotinaContinua
    {
        public override void Executar()
        {
            try
            {
                LoginHttpClient loginHttp = new LoginHttpClient("https://painel.velocepdv.com.br/");

                var credenciais = new Login();

                string response = loginHttp.Post("api/v1/acessar", credenciais).Result;
                LoginResult loginResult = JsonConvert.DeserializeObject<LoginResult>(response);
                LoginDAO loginDAO = new LoginDAO();
                loginDAO.AtualizarToken(loginResult.result.token);
                Service_Config.Token = loginResult.result.token;
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro ao solicitar novo Token. " + ex.ToString());
            }
        }
    }
}
