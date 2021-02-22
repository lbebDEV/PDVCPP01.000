using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Guardian
{
    class Guardian_Util
    {
        public string FormatarCaracter(string str)
        {
            string validos = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,.-";

            foreach (char c in str)
            {
                if (c == (char)13 || c == (char)10 || c == ' ')
                {
                    continue;
                }
                else if (!validos.Contains(c))
                {
                    str = str.Replace(c, '-');
                }
            }

            return str;
        }

        public static string ObterRecnoERP(string tabela)
        {
            string query = "";
            string recno = "";

            query =
            "SELECT (ISNULL(MAX(R_E_C_N_O_), 0) +1) AS RECNO FROM " + tabela + "";

            using (SqlConnection connection = new SqlConnection(ConexaoERP.Conexao()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            recno = reader["RECNO"].ToString();
                        }
                    }
                }
            }

            return recno;
        }
    }
}
