using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class ItemApp:InformacionRegistro
    {
        public int id { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public int app_id { get; set; }
        public string itemName { get; set; }
        public string tipo { get; set; }
        public int id_mother { get; set; }
        public List<ItemApp> items { get; set; }
    }

    public class ResponseItemApp
    {
        public int status { get; set; }
        public List<ItemApp> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
