using PDVCPP01._000.Guardian;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Config
{
    class Log_Config
    {
        public static bool Status { get; set; } = false;

        public static bool LogTxt { get; set; } = false;

        public static bool LogOcorrencia { get; set; } = false;
        public static bool LogEmail { get; set; } = false;
        public static bool LogRotina { get; set; } = false;
        public static bool LogAuditoria { get; set; } = false;

        public static bool CarregarConfiguracoes()
        {
            string query = "SELECT ZAL_REG, ZAL_OCOREN, ZAL_EMAIL, ZAL_ROTINA, ZAL_AUDIT " +
                "FROM "+ Tabelas_Guardian.ConfigLog;

            using (SqlConnection conexao = new SqlConnection(ConexaoERP.Conexao()))
            {
                using (SqlCommand command = new SqlCommand(query, conexao))
                {
                    conexao.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["ZAL_REG"].ToString().TrimStart().TrimEnd() == "S")
                                LogTxt = true;

                            if (reader["ZAL_OCOREN"].ToString().TrimStart().TrimEnd() == "S")
                                LogOcorrencia = true;

                            if (reader["ZAL_EMAIL"].ToString().TrimStart().TrimEnd() == "S")
                                LogEmail = true;

                            if (reader["ZAL_ROTINA"].ToString().TrimStart().TrimEnd() == "S")
                                LogRotina = true;

                            if (reader["ZAL_AUDIT"].ToString().TrimStart().TrimEnd() == "S")
                                LogAuditoria = true;
                        }
                    }
                }
            }

            Status = true;

            return Status;
        }
    }
}
