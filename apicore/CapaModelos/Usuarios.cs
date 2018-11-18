using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Usuarios
    {
        public int empid { get; set; }
        public string nombre { get; set; }
        public string area { get; set; }
    }

    public class ResponseUsuarios
    {
        public int status { get; set; }
        public List<Usuarios>  body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
