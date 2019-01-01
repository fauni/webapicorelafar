using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Conversacion
    {
        public int id_conversacion { get; set; }
        public string codigo_documento { get; set; }
        public string username { get; set; }
        public string nombre_usuario { get; set; }
        public DateTime fecha_hora { get; set; }
        public string mensaje { get; set; }
        public string estado { get; set; }
    }

    public class ResponseConversacion
    {
        public int status { get; set; }
        public List<Conversacion> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }

    public class ResponseAddConversacion
    {
        public int status { get; set; }
        public string message { get; set; }
    }
}
