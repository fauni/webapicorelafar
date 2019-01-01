using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class DetalleSolicitudCompraSC: InformacionRegistro
    {
        public int id_detalle_solicitud { get; set; }
        public string codigo_solicitud { get; set; }
        public string codigo_item { get; set; }
        public string descripcion_item { get; set; }
        public string tipo_item { get; set; }
        public DateTime fecha_arte { get; set; }
        public DateTime fecha_requerida { get; set; }
        public float cantidad { get; set; }
        public string unidad { get; set; }
        public int prioridad { get; set; }
        public string estado { get; set; }
    }

    public class ResponseGetDetalleSolicitud
    {
        public int status { get; set; }
        public DetalleSolicitudCompraSC body { get; set; }
        public string message { get; set; }
    }

    public class ResponseGetDetallesSolicitud
    {
        public int status { get; set; }
        public List<DetalleSolicitudCompraSC> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }

    public class ResponseAddDetalleSolicitud
    {
        public int status { get; set; }
        public string message { get; set; }
    }

#region CAMBIAR ESTADO DETALLE SOLICITUD DE COMPRA
    
    public class RequestUpdateEstadoDetalleSolicitudCompra 
    {
        public string codigo_solicitud { get; set; }
        public int id_detalle_solicitud { get; set; }
        public string usuario_modificacion { get; set; }
        public string estado { get; set; }
    }

    public class ResponseUpdateEstadoDetalleSolicitudCompra
    {
        public Boolean result { get; set; }
        public int status { get; set; }
        public string message { get; set; }
    }

#endregion
}
