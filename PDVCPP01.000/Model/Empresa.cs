using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Empresa
    {
        public string id_tbl_empresa { get; set; }
        public string razao_social { get; set; }
        public string cnpj { get; set; }
        public string logo { get; set; }
        public string endereco { get; set; }
        public string endereco_complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string site { get; set; }
        public string email { get; set; }
        public string cod_pais { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        public string dt_cadastro { get; set; }
        public string dt_alteracao { get; set; }
        public string dt_exclusao { get; set; }
        public string ie { get; set; }
        public string im { get; set; }
        public string nome_fantasia { get; set; }
        public string simples_nacional { get; set; }
        public string tem_certificado { get; set; }
        public string id_token_nfce { get; set; }
        public string token_nfce { get; set; }
        public string proxima_serie_nfce { get; set; }
        public string id_imposto_simples_nacional { get; set; }
        public string codigo_app_nfce { get; set; }
        public string fk_tbl_empresa_id_empresa { get; set; }
        public string matriz { get; set; }
        public string ativo { get; set; }
        public string cod_municipio { get; set; }
        public string cod_estado { get; set; }
        public string tipo { get; set; }
        public string codigo_interno { get; set; }
        public string venda_online { get; set; }
        public string incentivador_cultural { get; set; }
        public string incentivo_fiscal { get; set; }
        public string regime_tributario { get; set; }
        public string regime_tributario_especial { get; set; }
        public string api_referencia { get; set; }
        public string acessar_app { get; set; }
    }
}
