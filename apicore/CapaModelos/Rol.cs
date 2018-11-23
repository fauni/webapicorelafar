using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Rol
    {
        public int id_rol { get; set; }
        public string nombre_rol { get; set; }
        public string codigo_app { get; set; }
        public string descripcion { get; set; }
    }

    public class ResponseRol
    {
        public int status { get; set; }
        public List<Rol> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
