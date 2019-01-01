using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class SolicitudCompra:InformacionRegistro
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public string estado_transferencia { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public string usuario_anulacion { get; set; }
        public string motivo_anulacion { get; set; }
        public DateTime fecha_anulacion { get; set; }
        public string solicitante { get; set; }
        public string autorizador { get; set; }
        public string estado_autorizacion_superior { get; set; }
        public DateTime fecha_autorizacion_superior { get; set; }
        public string motivo_autorizacion { get; set; }
        public string tipo_compra { get; set; }
        public string codigo_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
    }

    public class ResponseGetSolicitud
    {
        public int status { get; set; }
        public SolicitudCompra body { get; set; }
        public string message { get; set; }
    }

    public class ResponseGetSolicitudes
    {
        public int status { get; set; }
        public List<SolicitudCompra> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }

    public class ResponseAddSolicitud
    {
        public int status { get; set; }
        public string message { get; set; }
    }

#region LISTADO DE SOLICITUD
    public class Solicitudcompralistado
    {
        public string codigo { get; set; }
        public int conversacion { get; set; }
        public string tipo { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public string estado_autorizacion_superior { get; set; }
        public string estado { get; set; }
        public string solicitante { get; set; }
        public string nombre_solicitante { get; set; }
    }

    public class ResponseGetSolicitudesXUsuario
    {
        public int status { get; set; }
        public List<Solicitudcompralistado> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }

#endregion

#region AUTORIZACION DE SOLICITUD
    public class RequestAnulacionSolicitud
    {
        public string codigo_solicitud { get; set; }
        public string motivo_anulacion { get; set; }
        public string usuario_anulacion { get; set; }
    }

    public class RequestAutorizacionSolicitud
    {
        public string codigo_solicitud { get; set; }
        public string motivo_autorizacion_superior { get; set; }
        public string estado_autorizacion { get; set; }
        public string autorizador { get; set; }
    }

#endregion

#region LISTADO DE SOLICITUDES POR ESTADO DEL AUTORIZADOR
    public class RequestEstadoAutorizador
    {
        public string id_superior { get; set; }
        public string estado_autorizacion { get; set; }
    }

#endregion
}
