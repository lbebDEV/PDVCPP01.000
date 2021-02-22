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
    class PagamentoDAO
    {

        public void Inserir(List<Pagamento> pagamentos, string nomeRotina, SqlConnection connection, SqlTransaction transaction, int recno)
        {
            string query = "";

            try
            {
                foreach (var item in pagamentos)
                {
                    query =
                        "INSERT INTO " + Tabelas_Guardian.ZAP + " " +
                        "(ZAP_FILIAL, ZAP_PEDPAG, ZAP_IDPED, ZAP_IDADQ, " +
                        "ZAP_IDBAND, ZAP_BANDEI, ZAP_ORDEM, ZAP_AUTCOD, " +
                        "ZAP_CODADQ, ZAP_PARCEL, ZAP_VALOR, ZAP_DTPAG, " +
                        "ZAP_PAG, ZAP_CODPRI, ZAP_CODSEC, ZAP_DESPRI, " +
                        "ZAP_DESSEC, ZAP_GUIUNQ, ZAP_TIPO, ZAP_STATUS, " +
                        "ZAP_IDTRAN, ZAP_JSONRE, ZAP_TROCO, ZAP_DTCAD, " +
                        "ZAP_DTALTE, ZAP_DTEXCL, ZAP_JSONPA, ZAP_IDNOTA, " +
                        "ZAP_POSFIS, ZAP_MOTCAN, ZAP_JSONCA, ZAP_IDCLI, " +
                        "ZAP_SALDO, ZAP_NUMCAR, ZAP_ADQUIR, " +
                        "D_E_L_E_T_, R_E_C_N_O_, R_E_C_D_E_L_, ZAP_LOGINC, ZAP_LOGINT) " +
                        "VALUES " +
                        "(" +
                        "'', " +
                        "'" + item.id_tbl_pedido_pagamento + "', " +
                        "'" + item.fk_tbl_pedido_pagamento_id_pedido + "', " +
                        "'" + item.fk_tbl_pedido_pagamento_id_adquirente + "', " +
                        "'" + item.fk_tbl_pedido_pagamento_id_bandeira + "', " +
                        "'" + item.bandeira + "', " +
                        "'" + item.order_id + "', " +
                        "'" + item.auth_code + "', " +
                        "'" + item.adquirente_code + "', " +
                        "'" + item.parcelas + "', " +
                        "'" + item.valor + "', " +
                        "'" + item.dt_pagamento + "', " +
                        "'" + item.pagamento_id + "', " +
                        "'" + item.codigo_primario + "', " +
                        "'" + item.codigo_secundario + "', " +
                        "'" + item.descricao_primario + "', " +
                        "'" + item.descricao_secundario + "', " +
                        "'" + item.guid_unique + "', " +
                        "'" + item.tipo + "', " +
                        "'" + item.status_codigo + "', " +
                        "'" + item.pagamento_transacao_id + "', " +
                        "'" + item.json_retorno + "', " +
                        "'" + item.troco + "', " +
                        "'" + item.dt_cadastro + "', " +
                        "'" + item.dt_alteracao + "', " +
                        "'" + item.dt_exclusao + "', " +
                        "'" + item.json_pagamento + "', " +
                        "'" + item.fk_tbl_pedido_pagamento_id_nota + "', " +
                        "'" + item.pos_fisico + "', " +
                        "'" + item.motivo_cancelamento + "', " +
                        "'" + item.json_cancelamento + "', " +
                        "'" + item.identificador_cliente + "', " +
                        "'" + item.saldo + "', " +
                        "'" + item.numero_cartao + "', " +
                        "'" + item.adquirente + "', " +
                        "'', " + recno + "," +
                        "'', " +
                        "'" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "', " +
                        " '')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                        recno++;
                    }
                }
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de inserção de pagamento do Pedido. Query:" + query + "/ EX: " + ex.ToString());
                throw ex;
            }
        }
    }
}
