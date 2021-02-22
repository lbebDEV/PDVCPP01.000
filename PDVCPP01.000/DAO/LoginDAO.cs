using PDVCPP01._000.Guardian;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.DAO
{
    class LoginDAO
    {
        public void AtualizarToken(string token)
        {
            string query = "";

            query =
                "UPDATE " + Tabelas_Guardian.ConfigUpload + " " +
                "SET ZAU_TOKEN = '" + token + "' ";
               

            using (SqlConnection connection = new SqlConnection(ConexaoERP.Conexao()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
      
    }
}
