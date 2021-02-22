using PDVCPP01._000.Config;
using PDVCPP01._000.Guardian;
using PDVCPP01._000.Model;
using PDVCPP01._000.ServiceLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.DAO
{
    class PedidoDAO
    {
        PedidoItemDAO pedidoItemDAO = new PedidoItemDAO();
        PagamentoDAO pagamentoDAO = new PagamentoDAO();
        ClienteDAO clienteDAO = new ClienteDAO();
        NotaDAO notaDAO = new NotaDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public List<Pedido> BuscarERP()
        {
            List<Pedido> Pedidos = new List<Pedido>();

            string query = "";

            try
            {
                query =
                 "SELECT " +
                "ZA5_IDPED " +
                "FROM " + Tabelas_Guardian.ZA5;

                using (SqlConnection connection = new SqlConnection(ConexaoERP.Conexao()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 500;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pedido pedido = new Pedido
                                {
                                    id_tbl_pedido = reader["ZA5_IDPED"].ToString().Trim(),
                                };

                                Pedidos.Add(pedido);
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Query: " + query + Environment.NewLine, ex);
            }
            return Pedidos;
        }

        public bool Inserir(Pedido pedido, string nome)
        {
            string query =
               "INSERT INTO " + Tabelas_Guardian.ZA5 + " " +
               "(" +
               "ZA5_FILIAL, ZA5_GUIUNQ, ZA5_IDPED, " +
               "ZA5_IDEMP, ZA5_PIDUSU, ZA5_DTCAD, " +
               "ZA5_DTALTE, ZA5_DTEXCL, ZA5_MOTCAN, " +
               "ZA5_VTOTAL, ZA5_VACRES, ZA5_VDESCO, " +
               "ZA5_PAGO, ZA5_IDCLI, ZA5_NUMDIS, " +
               "ZA5_NUMLOG, ZA5_NCAIXA, ZA5_REFERE, " +
               "ZA5_NOMCLI, ZA5_IDMESA, ZA5_ITEM, " +
               "ZA5_TIPO, ZA5_ASSINA, ZA5_STATUS, " +
               "ZA5_DTENTR, ZA5_DTFECH, ZA5_NUMEC, " +
               "ZA5_EMACLI, ZA5_BLOQ, ZA5_VENDON, " +
               "ZA5_PAGISO, ZA5_VERSAO, ZA5_ADQUIR, " +
               "ZA5_PROJET, ZA5_IDCAIX, ZA5_NUMPED, " +
               "ZA5_CNPJ, ZA5_NFANT, ZA5_RAZAO, ZA5_EMAIL, " +
               "D_E_L_E_T_, R_E_C_N_O_, R_E_C_D_E_L_, " +
               "ZA5_LOGINC, ZA5_LOGINT " +
               ") " +
               "VALUES " +
               "('', " +
               " '" + pedido.guid_unique + "', " +
               " '" + pedido.id_tbl_pedido + "', " +
               " '" + pedido.fk_tbl_pedido_id_empresa + "', " +
               " '" + pedido.fk_tbl_pedido_id_usuario + "', " +
               " '" + pedido.dt_cadastro + "', " +
               " '" + pedido.dt_alteracao + "', " +
               " '" + pedido.dt_exclusao + "', " +
               " '" + pedido.cancelamento_motivo + "', " +
               " '" + pedido.valor_total + "', " +
               " '" + pedido.valor_acrescimo + "', " +
               " '" + pedido.valor_desconto + "', " +
               " '" + pedido.pago + "', " +
               " '" + pedido.identificador_cliente + "', " +
               " '" + pedido.numero_dispositivo + "', " +
               " '" + pedido.numero_logico + "', " +
               " '" + pedido.numero_caixa + "', " +
               " '" + pedido.referencia + "', " +
               " '" + pedido.nome_cliente + "', " +
               " '" + pedido.fk_tbl_pedido_id_mesa + "', " +
               " '" + pedido.item + "', " +
               " '" + pedido.tipo + "', " +
               " '" + pedido.assinatura + "', " +
               " '" + pedido.status + "', " +
               " '" + pedido.dt_entrega + "', " +
               " '" + pedido.dt_fechamento + "', " +
               " '" + pedido.numero_ec + "', " +
               " '" + pedido.email_cliente + "', " +
               " '" + pedido.bloqueado + "', " +
               " '" + pedido.venda_online + "', " +
               " '" + pedido.pagamentos_json + "', " +
               " '" + pedido.versao + "', " +
               " '" + pedido.adquirente + "', " +
               " '" + pedido.projeto + "', " +
               " '" + pedido.fk_tbl_pedido_id_caixa + "', " +
               " '" + pedido.numero_pedido + "', " +
               " '" + pedido.cnpj + "', " +
               " '" + pedido.nome_fantasia + "', " +
               " '" + pedido.razao_social + "', " +
               " '" + pedido.email + "'," +
               "'', " +
               "'" + Guardian_Util.ObterRecnoERP(Tabelas_Guardian.ZA5) + "', " +
               "'', " +
               "'" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "', " +
               "'' " +
               ")";

            using (SqlConnection connection = new SqlConnection(ConexaoERP.Conexao()))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {

                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();

                            if (pedido.itens != null)
                                pedidoItemDAO.Inserir(pedido.itens, nome, connection, transaction, Convert.ToInt32(Guardian_Util.ObterRecnoERP(Tabelas_Guardian.ZA6)));

                            if (pedido.pagamentos != null)
                                pagamentoDAO.Inserir(pedido.pagamentos, nome, connection, transaction, Convert.ToInt32(Guardian_Util.ObterRecnoERP(Tabelas_Guardian.ZAP)));

                            if (pedido.cliente != null)
                                clienteDAO.Inserir(pedido.cliente, nome, connection, transaction, Convert.ToInt32(Guardian_Util.ObterRecnoERP(Tabelas_Guardian.ZA1)));

                            if (pedido.nota != null)
                                notaDAO.Inserir(pedido.nota, nome, connection, transaction, Convert.ToInt32(Guardian_Util.ObterRecnoERP(Tabelas_Guardian.ZAN)));

                            if (pedido.empresa != null)
                                empresaDAO.Inserir(pedido.empresa, nome, connection, transaction, Convert.ToInt32(Guardian_Util.ObterRecnoERP(Tabelas_Guardian.ZAE)));

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de inserção de Pedido. " + ex.ToString());
                        return false;
                    }
                }
            }
        }
    }
}