using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Item
    {
        public string id_tbl_pedido_item { get; set; }
        public string fk_tbl_pedido_item_id_pedido { get; set; }
        public string fk_tbl_pedido_item_id_combo { get; set; }
        public string fk_tbl_pedido_item_id_produto { get; set; }
        public string nome { get; set; }
        public string quantidade { get; set; }
        public string valor_unitario { get; set; }
        public string ean { get; set; }
        public string unidade { get; set; }
        public string desconto { get; set; }
        public string acrescimo { get; set; }
        public string imposto { get; set; }
        public string icms_cst_saida { get; set; }
        public string icms_aliquota_saida { get; set; }
        public string icms_base_saida { get; set; }
        public string pis_cst_saida { get; set; }
        public string pis_aliquota_saida { get; set; }
        public string pis_base_saida { get; set; }
        public string cofins_cst_saida { get; set; }
        public string cofins_aliquota_saida { get; set; }
        public string cofins_base_saida { get; set; }
        public string cfop_saida { get; set; }
        public string ibpt_federal { get; set; }
        public string ibpt_importa { get; set; }
        public string ibpt_estadual { get; set; }
        public string ibpt_municipal { get; set; }
        public string ibpt_chave { get; set; }
        public string cest { get; set; }
        public string ncm { get; set; }
        public string observacao { get; set; }
        public string status { get; set; }
        public string cancelado { get; set; }
        public string pago { get; set; }
        public string cancelado_motivo { get; set; }
        public string guid_unique { get; set; }
        public string ex { get; set; }
        public string dt_cadastro { get; set; }
        public string dt_alteracao { get; set; }
        public string dt_exclusao { get; set; }
        public string acrescimo_percentual { get; set; }
        public string desconto_percentual { get; set; }
        public string fk_tbl_pedido_item_id_produto_tamanho { get; set; }
        public string fk_tbl_pedido_item_id_pedido_item { get; set; }
        public string tipo_imposto { get; set; }
        public string issqn_natop { get; set; }
        public string issqn_aliquota { get; set; }
        public string issqn_base { get; set; }
        public string issqn_indincfisc { get; set; }
        public string issqn_codtributacao { get; set; }
        public string issqn_listserv { get; set; }
        public string preco_dependente { get; set; }
        public string fk_tbl_pedido_item_id_categoria { get; set; }
        public string nome_categoria { get; set; }
        public string dt_validade_categoria { get; set; }
        public string foto_categoria { get; set; }
        public string fk_tbl_pedido_item_id_fornecedor { get; set; }
        public string nome_fantasia_sobrenome_fornecedor { get; set; }
        public string cidade_fornecedor { get; set; }
        public string ean_trib { get; set; }
        public string id_cupom { get; set; }
        public string impressao { get; set; }
        public string codigo_interno { get; set; }
        public string venda_tipo { get; set; }
        public string gratis { get; set; }
        public string consumir { get; set; }
        public string dt_consumido { get; set; }
        public string pRedBCEfet { get; set; }
        public string vBCEfet { get; set; }
        public string pICMSEfet { get; set; }
        public string vICMSEfet { get; set; }
        public string fk_tbl_pedido_item_id_usuario { get; set; }
        public string identificador_cliente { get; set; }
        public string qtde_estoque { get; set; }
        public string codigo_qrcode { get; set; }
        public Fornecedor fornecedor { get; set; }
    }
}
