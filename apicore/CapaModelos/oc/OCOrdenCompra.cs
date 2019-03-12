using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class OCOrdenCompra
    {
        public int id_orden_compra { get; set; }
        public string codigo_orden { get; set; }
        public string tipo_orden { get; set; }
        public string estado { get; set; }
        public string estado_transferencia { get; set; }
        public DateTime fecha_orden { get; set; }
        public string codigo_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
        public string direccion_proveedor { get; set; }
        public int empid { get; set; }
        public string solicitante { get; set; }
        public string nombre_solicitante { get; set; }
        public string autorizador_sub { get; set; }
        public string autorizador_gerencia { get; set; }
        public string monto_total { get; set; }
        public string motivo_orden { get; set; }
        public DateTime fecha_entrega { get; set; }
        public string estado_autorizacion_subgerencia { get; set; }
        public string motivo_autorizacion_subgerencia { get; set; }
        public DateTime fecha_autorizacion_subgerencia { get; set; }
        public string estado_autorizacion_gerencia { get; set; }
        public string motivo_autorizacion_gerencia { get; set; }
        public DateTime fecha_autorizacion_gerencia { get; set; }
        public string tipo_compra { get; set; }
        public int incoterms { get; set; }
        public string encargado_compra { get; set; }
        public string nombre_encargado_compra { get; set; }
        public string usuario_anulacion { get; set; }
        public string motivo_anulacion { get; set; }
        public DateTime fecha_anulacion { get; set; }
        public string usuario_cierre { get; set; }
        public DateTime fecha_cierre { get; set; }
        public string usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }

    public class OCOrdenCompraX
    {
        public string id_orden_compra { get; set; }
        public string codigo_orden { get; set; }
        public string tipo_orden { get; set; }
        public string estado { get; set; }
        public string estado_transferencia { get; set; }
        public string fecha_orden { get; set; }
        public string codigo_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
        public string direccion_proveedor { get; set; }
        public string empid { get; set; }
        public string solicitante { get; set; }
        public string nombre_solicitante { get; set; }
        public string autorizador_sub { get; set; }
        public string autorizador_gerencia { get; set; }
        public string monto_total { get; set; }
        public string motivo_orden { get; set; }
        public string fecha_entrega { get; set; }
        public string estado_autorizacion_subgerencia { get; set; }
        public string motivo_autorizacion_subgerencia { get; set; }
        public string fecha_autorizacion_subgerencia { get; set; }
        public string estado_autorizacion_gerencia { get; set; }
        public string motivo_autorizacion_gerencia { get; set; }
        public string fecha_autorizacion_gerencia { get; set; }
        public string tipo_compra { get; set; }
        public string incoterms { get; set; }
        public string encargado_compra { get; set; }
        public string nombre_encargado_compra { get; set; }
        public string usuario_anulacion { get; set; }
        public string motivo_anulacion { get; set; }
        public string fecha_anulacion { get; set; }
        public string usuario_cierre { get; set; }
        public string fecha_cierre { get; set; }
        public string usuario_creacion { get; set; }
        public string fecha_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public string fecha_modificacion { get; set; }
    }

    public class ResponseOrdenCompra
    {
        public int status { get; set; }
        public OCOrdenCompra body { get; set; }
        public string message { get; set; }
    }

    public class ResponseAddOrdenCompra
    {
        public int status { get; set; }
        public string message { get; set; }
    }

    public class OrdenCompraListAbastecimiento
    {
        public string codigo_orden { get; set; }
        public int conversacion { get; set; }
        public DateTime fecha_orden { get; set; }
        public string titular { get; set; }
        public string tipo_orden { get; set; }
        public string motivo_orden { get; set; }
        public string estado_autorizacion_subgerencia { get; set; }
        public string estado_autorizacion_gerencia { get; set; }
        public float monto_total { get; set; }
        public string estado_transferencia { get; set; }
    }

    public class ResponseListadoOrdenCompraAbastecimiento
    {
        public int status { get; set; }
        public List<OrdenCompraListAbastecimiento> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }

    public class DeleteOrdenCompra
    {
        public string codigo_orden { get; set; }
        public string usuario_modificacion { get; set; }
    }
}
