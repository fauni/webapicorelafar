using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class UserRol
    {
        public int id { get; set; }
        public string username { get; set; }
        public int id_rol { get; set; }
    }

    public class RequestUserApp
    {
        public string username { get; set; }
        public int id_app { get; set; }
    }

    public class ResponseUserRol
    {
        public int status { get; set; }
        public UserRol body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
