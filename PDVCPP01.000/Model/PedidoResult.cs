using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Model
{
    public class PedidoResult
    {
        public string Ok { get; set; }
        public string Message { get; set; }
        public List<Pedido> result;
    }
}
