using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Cliente
    {
        public string id_tbl_pedido_cliente { get; set; }
        public string fk_tbl_pedido_cliente_id_pedido { get; set; }
        public string fk_tbl_pedido_cliente_id_cliente { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string tipo { get; set; }
        public string identificador { get; set; }
        public string rg { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public string dt_nascimento { get; set; }
        public string ddi_telefone { get; set; }
        public string ddd_telefone { get; set; }
        public string telefone { get; set; }
        public string ddi_celular { get; set; }
        public string ddd_celular { get; set; }
        public string celular { get; set; }
        public string logradouro { get; set; }
        public string uf { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string fk_tbl_pedido_cliente_id_pedido_cliente { get; set; }
        public string ie { get; set; }
        public string im { get; set; }
    }
}
