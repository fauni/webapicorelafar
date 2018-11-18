using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Fabricante : InformacionRegistro
    {
        public int id_fabricante { get; set; }
        public string nombre_fabricante { get; set; }
    }

    public class ResponseFabricante
    {
        public int status { get; set; }
        public List<Fabricante> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
