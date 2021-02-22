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
    class ClienteDAO
    {
        public bool Inserir(Cliente cliente, string nome, SqlConnection connection, SqlTransaction transaction, int recno)
        {
            string query = "";

            try
            {
                query =
                   "INSERT INTO " + Tabelas_Guardian.ZA1 + " " +
                   "(ZA1_FILIAL, ZA1_IDCLIC ,ZA1_NOME, ZA1_SNOME, " +
                   "ZA1_TIPO ,ZA1_ID, ZA1_RG, ZA1_EMAIL, " +
                   "ZA1_SEXO, ZA1_DTNAS, ZA1_DDIT, ZA1_DDDT, " +
                   "ZA1_TEL, ZA1_DDIC, ZA1_DDDC, ZA1_CEL, " +
                   "ZA1_LOGINC, ZA1_LOGINT, ZA1_IDEND, ZA1_LOGR, " +
                   "ZA1_NUM, ZA1_COMPL, ZA1_CEP, ZA1_BAIRRO, " +
                   "ZA1_MUNIC, ZA1_UF, ZA1_IDCLIE, D_E_L_E_T_, " +
                   "R_E_C_N_O_, R_E_C_D_E_L_, ZA1_DTCAD, ZA1_DTALT, " +
                   "ZA1_DTEXC, ZA1_ID_T_C, ZA1_CDPAIS, ZA1_CODMUN) " +
                   "VALUES " +
                   "(" +
                   " '', " +
                   " '" + cliente.fk_tbl_pedido_cliente_id_cliente + "', " +
                    " '" + cliente.nome + "', " +
                   " '" + cliente.sobrenome + "', " +
                   " '" + cliente.tipo + "', " +
                   " '" + cliente.identificador + "', " +
                   " '" + cliente.rg + "', " +
                   " '" + cliente.email + "', " +
                   " '" + cliente.sexo + "', " +
                   " '" + cliente.dt_nascimento + "', " +
                   " '" + cliente.ddi_telefone + "', " +
                   " '" + cliente.ddd_telefone + "', " +
                   " '" + cliente.telefone + "', " +
                   " '" + cliente.ddi_celular + "', " +
                   " '" + cliente.ddd_celular + "', " +
                   " '" + cliente.celular + "', " +
                   "'" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "', " +
                   "'', " +
                   "'', " +
                   " '" + cliente.logradouro + "', " +
                   " '" + cliente.numero + "', " +
                   " '" + cliente.complemento + "', " +
                   " '" + cliente.cep + "', " +
                   " '" + cliente.bairro + "', " +
                   " '" + cliente.cidade + "', " +
                   " '" + cliente.uf + "', " +
                   " '" + cliente.fk_tbl_pedido_cliente_id_pedido + "', " +
                   " '', " +
                   " " + recno + ", " +
                   " '', " +
                   " '', " + //ZA1_DTCAD
                   " '', " + //ZA1_DTALT
                   " '', " + //ZA1_DTEXC
                   " '', " + //ZA1_ID_T_C
                   " '', " + //ZA1_CDPAIS
                   " '' " + //ZA1_CODMUN
                   ")";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de inserção de Cliente. Query: " + query + " / EX: " + ex.ToString());
                return false;
            }
        }
    }
}
