using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class SCFile
    {
        public int id { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public string NombreGenerico { get; set; }
        public string codigo_solicitud { get; set; }
        public Int64 tamanio { get; set; }
    }

    public class ResponseSaveSCFile
    {
        public int status { get; set; }
        public Boolean ok { get; set; }
        public string message { get; set; }
    }

    public class ResponseSCFile
    {
        public int status { get; set; }
        public List<SCFile> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
