using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class OCDetalleOrdenCompra
    {
        public int id_detalle_solicitud { get; set; }
        public string codigo_solicitud { get; set; }
        public string codigo_orden { get; set; }
        public string codigo_item { get; set; }
        public string descripcion_item { get; set; }
        public string tipo_item { get; set; }
        public DateTime fecha_arte { get; set; }
        public DateTime fecha_requerida { get; set; }
        public float cantidad { get; set; }
        public string unidad { get; set; }
        public float precio_unitario { get; set; }
        public float sub_total { get; set; }
        public string estado { get; set; }
        public string usuario_creacion { get; set; }
        public string usuario_modificacion { get; set; }
    }

    public class OCResponseDetalleOrdenCompra
    {
        public int status { get; set; }
        public List<OCDetalleOrdenCompra> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }

    public class ResponseAddDetalleOrdenCompra
    {
        public Boolean status { get; set; }
        public string  message { get; set; }
    }
}
