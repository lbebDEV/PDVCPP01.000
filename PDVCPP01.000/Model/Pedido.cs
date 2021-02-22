using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Pedido
    {
        public string guid_unique { get; set; }
        public string id_tbl_pedido { get; set; }
        public string fk_tbl_pedido_id_empresa { get; set; }
        public string fk_tbl_pedido_id_usuario { get; set; }
        public string dt_cadastro { get; set; }
        public string dt_alteracao { get; set; }
        public string dt_exclusao { get; set; }
        public string cancelamento_motivo { get; set; }
        public string valor_total { get; set; }
        public string valor_acrescimo { get; set; }
        public string valor_desconto { get; set; }
        public string pago { get; set; }
        public string identificador_cliente { get; set; }
        public string numero_dispositivo { get; set; }
        public string numero_logico { get; set; }
        public string numero_caixa { get; set; }
        public string referencia { get; set; }
        public string nome_cliente { get; set; }
        public string fk_tbl_pedido_id_mesa { get; set; }
        public string item { get; set; }
        public string tipo { get; set; }
        public string assinatura { get; set; }
        public string status { get; set; }
        public string dt_entrega { get; set; }
        public string dt_fechamento { get; set; }
        public string numero_ec { get; set; }
        public string email_cliente { get; set; }
        public string bloqueado { get; set; }
        public string venda_online { get; set; }
        public string pagamentos_json { get; set; }
        public string versao { get; set; }
        public string adquirente { get; set; }
        public string projeto { get; set; }
        public string fk_tbl_pedido_id_caixa { get; set; }
        public string numero_pedido { get; set; }
        public string cnpj { get; set; }
        public string nome_fantasia { get; set; }
        public string razao_social { get; set; }
        public string email { get; set; }
        public List<Item> itens;
        public List<Pagamento> pagamentos;
        public Cliente cliente;
        public Nota nota;
        public Empresa empresa;
    }
}
