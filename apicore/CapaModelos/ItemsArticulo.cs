using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class ItemArticuloSC
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BuyUnitMsr { get; set; }
    }

    public class ResponseItemArticuloSC
    {
        public int status { get; set; }
        public List<ItemArticuloSC> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
