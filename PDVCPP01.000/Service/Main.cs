using PDVCPP01._000.Config;
using PDVCPP01._000.Controllers;
using PDVCPP01._000.Guardian;
using PDVCPP01._000.ServiceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Service
{
    class Main
    {
        public static string IdCiclo { get; set; }

        public void ExecucaoServico()
        {
            IdCiclo = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                Service_Config.CarregarConfiguracoes();
                Guardian_LogTxt.LogControle(TipoControle.Ciclo_Iniciado);
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Iniciado,"");
                if (Service_Config.Status)
                {
                    TokenController tokenController = new TokenController();
                    tokenController.Executar();

                    PedidosController pedidosController = new PedidosController();
                    pedidosController.Executar();
                }
                Guardian_LogTxt.LogControle(TipoControle.Ciclo_Finalizado);
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Finalizado,"");
            }
            catch (Exception ex)
            {
                Guardian_LogTxt.LogAplicacao(Service_Config.NomeServico, ex.ToString());
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina Principal. " + ex.ToString());
            }
        }
    }
}
