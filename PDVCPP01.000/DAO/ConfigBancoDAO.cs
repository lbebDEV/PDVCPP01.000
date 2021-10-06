using PDVCPP01._000.Config;
using PDVCPP01._000.Guardian;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.DAO
{
    class ConfigBancoDAO
    {
        public void BuscarConfigs()
        {
            string query =
                "SELECT ZAU_CAD , ZAU_DELAY, ZAU_TPUPL, ZAU_VLUPL, ZAU_DLUPL, ZAU_DLUPL, ZAU_HRINIC, ZAU_HRFIM, ZAU_TOKEN , ZAU_LOGIN, ZAU_SENHA, ZAU_DTRET " +
                "FROM " + Tabelas_Guardian.ConfigUpload + " " +
                "WHERE ZAU_ROTINA  = 'PEDIDO'";

            using (SqlConnection conexao = new SqlConnection(ConexaoERP.Conexao()))
            {
                using (SqlCommand command = new SqlCommand(query, conexao))
                {
                    conexao.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["ZAU_CAD"].ToString().TrimStart().TrimEnd() == "S")
                                Service_Config.CadastroHabilitado = true;

                            Service_Config.DelayCiclo = Convert.ToDouble(reader["ZAU_DELAY"].ToString().TrimStart().TrimEnd());
                            Service_Config.TipoUpload = reader["ZAU_TPUPL"].ToString().TrimStart().TrimEnd();
                            Service_Config.ValorUpload = reader["ZAU_VLUPL"].ToString().TrimStart().TrimEnd();
                            Service_Config.DelayUpload = Convert.ToDouble(reader["ZAU_DLUPL"].ToString().TrimStart().TrimEnd());
                            Service_Config.UploadHoraInicio = Convert.ToDateTime(reader["ZAU_HRINIC"].ToString().TrimStart().TrimEnd());
                            Service_Config.UploadHoraFim = Convert.ToDateTime(reader["ZAU_HRFIM"].ToString().TrimStart().TrimEnd());
                            Service_Config.Token = reader["ZAU_TOKEN"].ToString().TrimStart().TrimEnd();
                            Service_Config.Login = reader["ZAU_LOGIN"].ToString().TrimStart().TrimEnd();
                            Service_Config.Senha = reader["ZAU_SENHA"].ToString().TrimStart().TrimEnd();
                            Service_Config.DataRetrocesso = reader["ZAU_DTRET"].ToString().TrimStart().TrimEnd();
                        }
                    }
                }
            }
        }
    }
}
