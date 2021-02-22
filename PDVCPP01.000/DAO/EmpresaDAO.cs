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
    class EmpresaDAO
    {
        public bool Inserir(Empresa empresa, string nome, SqlConnection connection, SqlTransaction transaction, int recno)
        {
            string query = "";

            try
            {
                query =
                   "INSERT INTO " + Tabelas_Guardian.ZAE + " " +
                   "(ZAE_FILIAL, ZAE_IDEMP, ZAE_RAZAO, ZAE_CNPJ, " +
                   "ZAE_LOGO, ZAE_END, ZAE_ENDCOM, ZAE_CEP, " +
                   "ZAE_BAIRRO, ZAE_MUN, ZAE_ESTADO, ZAE_SITE, " +
                   "ZAE_EMAIL, ZAE_IDPAIS, ZAE_DDD, ZAE_TEL, " +
                   "ZAE_DTCAD, ZAE_DTALT, ZAE_DTEXCL, ZAE_IE, " +
                   "ZAE_IM, ZAE_NFANT, ZAE_SIMNAC, ZAE_CERT, " +
                   "ZAE_IDNFCE, ZAE_TKNFCE, ZAE_PSNFCE, ZAE_ISNAC, " +
                   "ZAE_CODAPP, ZAE_EIDEMP, ZAE_MATRIZ, ZAE_ATIVO, " +
                   "ZAE_CODMUN, ZAE_CODEST, ZAE_TIPO, ZAE_CODINT, " +
                   "ZAE_VENDON, ZAE_INCULT, ZAE_INFISC, ZAE_REGTRI, " +
                   "ZAE_RTRIES, ZAE_APIREF, ZAE_ACEAPI, ZAE_NUMEND, " +
                   "D_E_L_E_T_, R_E_C_N_O_, R_E_C_D_E_L_, ZAE_LOGINC, ZAE_LOGINT) " +
                   "VALUES " +
                   "(" +
                   " '', " +
                   " '"+empresa.id_tbl_empresa + "', " +
                   " '"+empresa.razao_social + "', " +
                   " '"+empresa.cnpj + "', " +
                   " '"+empresa.logo + "', " +
                   " '"+empresa.endereco + "', " +
                   " '"+empresa.endereco_complemento + "', " +
                   " '"+empresa.cep + "', " +
                   " '"+empresa.bairro + "', " +
                   " '"+empresa.cidade + "', " +
                   " '"+empresa.estado + "', " +
                   " '"+empresa.site + "', " +
                   " '"+empresa.email + "', " +
                   " '"+empresa.cod_pais + "', " +
                   " '"+empresa.ddd + "', " +
                   " '"+empresa.telefone + "', " +
                   " '"+empresa.dt_cadastro + "', " +
                   " '"+empresa.dt_alteracao + "', " +
                   " '"+empresa.dt_exclusao + "', " +
                   " '"+empresa.ie + "', " +
                   " '"+empresa.im + "', " +
                   " '"+empresa.nome_fantasia + "', " +
                   " '"+empresa.simples_nacional + "', " +
                   " '"+empresa.tem_certificado + "', " +
                   " '"+empresa.id_token_nfce + "', " +
                   " '"+empresa.token_nfce + "', " +
                   " '"+empresa.proxima_serie_nfce + "', " +
                   " '"+empresa.id_imposto_simples_nacional + "', " +
                   " '"+empresa.codigo_app_nfce + "', " +
                   " '"+empresa.fk_tbl_empresa_id_empresa + "', " +
                   " '"+empresa.matriz + "', " +
                   " '"+empresa.ativo + "', " +
                   " '"+empresa.cod_municipio + "', " +
                   " '"+empresa.cod_estado + "', " +
                   " '"+empresa.tipo + "', " +
                   " '"+empresa.codigo_interno + "', " +
                   " '"+empresa.venda_online + "', " +
                   " '"+empresa.incentivador_cultural + "', " +
                   " '"+empresa.incentivo_fiscal + "', " +
                   " '"+empresa.regime_tributario + "', " +
                   " '"+empresa.regime_tributario_especial + "', " +
                   " '"+empresa.api_referencia + "', " +
                   " '"+empresa.acessar_app + "', " +
                   " '"+empresa.acessar_app + "', " +
                   " '', " +
                   " " + recno + ", " +
                   " '', " +
                   "'" + DateTime.Now.ToString("yyyyMMdd HH:mm") + "', " +
                   " '' " +
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
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de inserção de Empresa. Query: " + query + " / EX: " + ex.ToString());
                return false;
            }
        }
    }
}
