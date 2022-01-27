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
    class NotaDAO
    {
        Guardian_Util guardian_Util = new Guardian_Util();

        public void Inserir(Nota nota, string nomeRotina, SqlConnection connection, SqlTransaction transaction, int recno)
        {
            string query = "";
            byte[] qrCode = null;
            byte[] xml = null;
            try
            {
                if (nota.qr_code != null)
                    qrCode = Encoding.UTF8.GetBytes(guardian_Util.FormatarCaracter(nota.qr_code));
                else
                    qrCode = Encoding.UTF8.GetBytes(guardian_Util.FormatarCaracter("SEM DADOS"));

                if (nota.xml != null)
                    xml = Encoding.UTF8.GetBytes(guardian_Util.FormatarCaracter(nota.xml));
                else
                    xml = Encoding.UTF8.GetBytes(guardian_Util.FormatarCaracter("SEM DADOS"));

                query =
                    "INSERT INTO " + Tabelas_Guardian.ZAN + " " +
                    "(ZAN_FILIAL, ZAN_NOTA, ZAN_IDEMP, ZAN_IDPED, " +
                    "ZAN_NUM, ZAN_SERIE, ZAN_CHAVE, ZAN_AMBIEN, " +
                    "ZAN_DATA, ZAN_STATUS, ZAN_DTRECE, ZAN_PRTREC, " +
                    "ZAN_DTCAN, ZAN_PRTCAN, ZAN_JUSCAN, ZAN_ERRO, " +
                    "ZAN_XML, ZAN_VALOR, ZAN_IDCLI, ZAN_TROCO, " +
                    "ZAN_NDISP, ZAN_NCAIXA, ZAN_IDLOTE, ZAN_QRCODE, " +
                    "ZAN_RESIMP, ZAN_EMISSA, ZAN_STCANC, ZAN_ERCANC, " +
                    "ZAN_CNPJ, ZAN_JUSVAL, ZAN_NVALOR, ZAN_GUIUNQ, " +
                    "ZAN_DTINTE, ZAN_CODFUN, D_E_L_E_T_, R_E_C_N_O_, " +
                    "R_E_C_D_E_L_, ZAN_LOGINC, ZAN_LOGINT) " +
                    "VALUES " +
                    "(" +
                    "'', " +
                    "'" + nota.id_tbl_nota + "', " +
                    "'" + nota.fk_tbl_nota_id_empresa + "', " +
                    "'" + nota.fk_tbl_nota_id_pedido + "', " +
                    "'" + nota.numero + "', " +
                    "'" + nota.serie + "', " +
                    "'" + nota.chave + "', " +
                    "'" + nota.ambiente + "', " +
                    "'" + nota.data + "', " +
                    "'" + nota.status + "', " +
                    "'" + nota.data_recebido + "', " +
                    "'" + nota.protocolo_recebido + "', " +
                    "'" + nota.data_cancelado + "', " +
                    "'" + nota.protocolo_cancelado + "', " +
                    "'" + nota.justificativa_cancelado + "', " +
                    "'" + nota.erro + "', " +
                    "@xml, " +
                     "'" + nota.valor + "', " +
                     "'" + nota.identificador_cliente + "', " +
                     "'" + nota.troco + "', " +
                     "'" + nota.numero_dispositivo + "', " +
                     "'" + nota.numero_caixa + "', " +
                     "'" + nota.id_lote + "', " +
                     "@qrcode, " +
                     "'" + nota.resumo_imposto + "', " +
                     "'" + nota.emissao + "', " +
                     "'" + nota.status_cancelado + "', " +
                     "'" + nota.erro_cancelado + "', " +
                     "'" + nota.cnpj + "', " +
                     "'" + nota.justificativa_valor + "', " +
                     "'" + nota.novo_valor + "', " +
                     "'" + nota.guid_unique + "', " +
                     "'" + nota.data_integrado + "', " +
                     "'" + nota.cod_funcionario + "', " +
                     "'', " + recno + ", " +
                     "''," +
                     "'" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "', " +
                     "'')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@qrcode", qrCode);
                    command.Parameters.AddWithValue("@xml", xml);
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de inserção de nota do Pedido. Query:" + query + "/ EX: " + ex.ToString());
                Guardian_LogTxt.LogAplicacao(Service_Config.NomeServico, query + " | " + ex.ToString());
                throw ex;
            }
        }
    }
}
