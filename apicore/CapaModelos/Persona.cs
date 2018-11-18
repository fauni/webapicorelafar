using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Persona
    {
        public int empid { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
    }

    public class ResponsePersona
    {
        public int status { get; set; }
        public List<Persona> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
