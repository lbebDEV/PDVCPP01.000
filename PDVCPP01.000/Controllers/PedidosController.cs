using PDVCPP01._000.Config;
using PDVCPP01._000.DAO;
using PDVCPP01._000.HttpClients;
using PDVCPP01._000.Model;
using PDVCPP01._000.ServiceLog;
using PDVCPP01._001.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PDVCPP01._000.Controllers
{
    class PedidosController : RotinaContinua
    {
        PedidoDAO pedidoDAO = new PedidoDAO();
        public PedidosController()
        {
            Nome = "Pedido Cadastro";
        }

        public override void Executar()
        {
            try
            {
                HttpClientBase<PedidoResult> httpPedidoBase = new HttpClientBase<PedidoResult>("http://api.velocepdv.com.br/");

                if (Service_Config.CadastroHabilitado)
                {
                    httpPedidoBase.InsertToken();
                    PedidoResult result = httpPedidoBase.Get("api/v1/pedidos");
                    List<Pedido> resultERP = pedidoDAO.BuscarERP();
                    SincronizarNovos(resultERP, result.result);
                }
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de Pedido. " + ex.ToString());
            }
        }

        public void SincronizarNovos(List<Pedido> pedidoERP, List<Pedido> pedidoAPI)
        {
            try
            {
                int countCadastrados = 0;

                HashSet<string> listaPortal = new HashSet<string>(pedidoERP.Select(s => s.id_tbl_pedido));

                List<Pedido> novosAcessos = pedidoAPI.Where(m => !listaPortal.Contains(m.id_tbl_pedido)).ToList();

                foreach (var pedido in novosAcessos)
                {
                    if (pedidoDAO.Inserir(pedido, Nome))
                        countCadastrados++;
                }

                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Auditoria, "Numero de Pedidos cadastrados: " + countCadastrados);
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de Sincronizar Pedidos. " + ex.ToString());
            }
           
        }
    }
}
