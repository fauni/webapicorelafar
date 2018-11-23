using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class Departamento
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int UserSign { get; set; }
        public string Father { get; set; }
    }

    public class ResponseDepartamento
    {
        public int status { get; set; }
        public List<Departamento> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
