using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class OCTipoCompraEncargado
    {
        public int id_tipo { get; set; }
        public string codigo_tipo_compra { get; set; }
        public string descripcion { get; set; }
        public string username { get; set; }
        public string nombre_encargado { get; set; }
    }

    public class ResponseTipoCompraEncargado
    {
        public int status { get; set; }
        public List<OCTipoCompraEncargado> body { get; set; }
        public string message { get; set; }
        public int length { get; set; }
    }

    public class ResponseTipoCompraEncargadoSingle
    {
        public int status { get; set; }
        public OCTipoCompraEncargado body { get; set; }
        public string message { get; set; }
    }
}
