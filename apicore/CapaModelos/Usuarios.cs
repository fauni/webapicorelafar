using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class SCUsuarios
    {
        public int userid { get; set; }
        public int idsap { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string nombre_completo { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string regional { get; set; }
        public string area { get; set; }
    }

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
