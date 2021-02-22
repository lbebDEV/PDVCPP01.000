using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Nota
    {
        public string id_tbl_nota { get; set; }
        public string fk_tbl_nota_id_empresa { get; set; }
        public string fk_tbl_nota_id_pedido { get; set; }
        public string numero { get; set; }
        public string serie { get; set; }
        public string chave { get; set; }
        public string ambiente { get; set; }
        public string data { get; set; }
        public string status { get; set; }
        public string data_recebido { get; set; }
        public string protocolo_recebido { get; set; }
        public string data_cancelado { get; set; }
        public string protocolo_cancelado { get; set; }
        public string justificativa_cancelado { get; set; }
        public string erro { get; set; }
        public string xml { get; set; }
        public string valor { get; set; }
        public string identificador_cliente { get; set; }
        public string troco { get; set; }
        public string numero_dispositivo { get; set; }
        public string numero_caixa { get; set; }
        public string id_lote { get; set; }
        public string qr_code { get; set; }
        public string resumo_imposto { get; set; }
        public string emissao { get; set; }
        public string status_cancelado { get; set; }
        public string erro_cancelado { get; set; }
        public string cnpj { get; set; }
        public string justificativa_valor { get; set; }
        public string novo_valor { get; set; }
        public string guid_unique { get; set; }
        public string data_integrado { get; set; }
        public string cod_funcionario { get; set; }
    }
}
