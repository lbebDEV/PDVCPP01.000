using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class Pagamento
    {
        public string id_tbl_pedido_pagamento { get; set; }
        public string fk_tbl_pedido_pagamento_id_pedido { get; set; }
        public string fk_tbl_pedido_pagamento_id_adquirente { get; set; }
        public string fk_tbl_pedido_pagamento_id_bandeira { get; set; }
        public string bandeira { get; set; }
        public string order_id { get; set; }
        public string auth_code { get; set; }
        public string adquirente_code { get; set; }
        public string parcelas { get; set; }
        public string valor { get; set; }
        public string dt_pagamento { get; set; }
        public string pagamento_id { get; set; }
        public string codigo_primario { get; set; }
        public string codigo_secundario { get; set; }
        public string descricao_primario { get; set; }
        public string descricao_secundario { get; set; }
        public string guid_unique { get; set; }
        public string tipo { get; set; }
        public string status_codigo { get; set; }
        public string pagamento_transacao_id { get; set; }
        public string json_retorno { get; set; }
        public string troco { get; set; }
        public string dt_cadastro { get; set; }
        public string dt_alteracao { get; set; }
        public string dt_exclusao { get; set; }
        public string json_pagamento { get; set; }
        public string fk_tbl_pedido_pagamento_id_nota { get; set; }
        public string pos_fisico { get; set; }
        public string motivo_cancelamento { get; set; }
        public string json_cancelamento { get; set; }
        public string identificador_cliente { get; set; }
        public string saldo { get; set; }
        public string numero_cartao { get; set; }
        public string adquirente { get; set; }
    }
}
