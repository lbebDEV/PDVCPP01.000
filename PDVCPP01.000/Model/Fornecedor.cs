using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Fornecedor
    {
        public string id_tbl_fornecedor { get; set; }
        public string fk_tbl_fornecedor_id_empresa { get; set; }
        public string identificador { get; set; }
        public string tipo { get; set; }
        public string razao_social_nome { get; set; }
        public string nome_fantasia_sobrenome { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string site { get; set; }
        public string email { get; set; }
        public string consignado { get; set; }
        public string consignado_percent { get; set; }
        public string cod_pais { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        public string cod_municipio { get; set; }
        public string dt_cadastro { get; set; }
        public string dt_alteracao { get; set; }
        public string dt_exclusao { get; set; }
        public string modelo { get; set; }
        public string estoque { get; set; }
        public string informacoes { get; set; }
        public string codigo_interno { get; set; }
        public string coordenadas { get; set; }
    }
}
