using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Proveedor
    {
        
    }

    public class ProveedorSC
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string MailAddres { get; set; }
        public string CntctPrsn { get; set; }
        public string Cellular { get; set; }
    }

    public class ResponseProveedoresSC
    {
        public int status { get; set; }
        public List<ProveedorSC> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
