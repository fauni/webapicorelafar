using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class NumeroOrdenCompra
    {

    }

    public class RequestUpdateEstadoSubidaOrden
    {
        public Int64 numero_orden_compra { get; set; }
        public string estado_transferencia { get; set; }
        public string codigo_orden { get; set; }
    }

    public class ResponseNumeroOrdenCompra
    {
        public int status { get; set; }
        public Int64 body { get; set; }
        public string message { get; set; }
    }

    public class ResponseVerificaTransferenciaOC
    {
        public int status { get; set; }
        public Boolean result { get; set; }
    }
}
