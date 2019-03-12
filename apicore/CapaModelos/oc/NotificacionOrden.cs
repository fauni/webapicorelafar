using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class NotificacionOrden
    {
        public string codigo_solicitud { get; set; }
        public string codigo_orden { get; set; }
        public string solicitante { get; set; }
        public string autorizador { get; set; }
    }

    public class ResponseNotificacionCreateOrden
    {
        public int status { get; set; }
        public List<NotificacionOrden> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
