using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using System.Data;

namespace CapaNegocio
{
    public class SCOrdenCompraNegocio
    {
        public OCOrdenCompra GetOrdenCompra(string codigo_orden)
        {
            OCOrdenCompra oc = new OCOrdenCompra();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_orden_get_por_codigo]");
                consulta.AgregarParametro("@codigo_orden", codigo_orden);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    OCOrdenCompra a = new OCOrdenCompra
                    {
                        id_orden_compra = Convert.ToInt32(item["id_orden_compra"]),
                        codigo_orden = (item["codigo_orden"]).ToString(),
                        tipo_orden = (item["tipo_orden"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        estado_transferencia = (item["estado_transferencia"]).ToString(),
                        fecha_orden = Convert.ToDateTime(item["fecha_orden"]),
                        codigo_proveedor = (item["codigo_proveedor"]).ToString(),
                        nombre_proveedor = (item["nombre_proveedor"]).ToString(),
                        direccion_proveedor = (item["direccion_proveedor"]).ToString(),
                        empid = Convert.ToInt32(item["empid"]),
                        solicitante = (item["solicitante"]).ToString(),
                        nombre_solicitante = (item["nombre_solicitante"]).ToString(),
                        autorizador_sub = (item["autorizador_sub"]).ToString(),
                        autorizador_gerencia = (item["autorizador_gerencia"]).ToString(),
                        monto_total = (item["monto_total"]).ToString(),
                        motivo_orden = (item["motivo_orden"]).ToString(),
                        fecha_entrega = Convert.ToDateTime(item["fecha_entrega"]),
                        estado_autorizacion_subgerencia = (item["estado_autorizacion_subgerencia"]).ToString(),
                        motivo_autorizacion_subgerencia = (item["motivo_autorizacion_subgerencia"]).ToString(),
                        fecha_autorizacion_subgerencia = Convert.ToDateTime(item["fecha_autorizacion_subgerencia"]),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString(),
                        motivo_autorizacion_gerencia = (item["motivo_autorizacion_gerencia"]).ToString(),
                        fecha_autorizacion_gerencia = Convert.ToDateTime(item["fecha_autorizacion_gerencia"]),
                        tipo_compra = (item["tipo_compra"]).ToString(),
                        incoterms = Convert.ToInt32(item["incoterms"]),
                        encargado_compra = (item["encargado_compra"]).ToString(),
                        nombre_encargado_compra = (item["nombre_encargado_compra"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    oc = a;
                }
                return oc;
            }
            catch (Exception ex)
            {
                return oc;
            }
        }

        public List<OrdenCompraListAbastecimiento> GetOrdenesCompras()
        {
            List<OrdenCompraListAbastecimiento> loc = new List<OrdenCompraListAbastecimiento>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_orden_list_abast]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    OrdenCompraListAbastecimiento a = new OrdenCompraListAbastecimiento
                    {
                        codigo_orden = (item["codigo_orden"]).ToString(),
                        conversacion = Convert.ToInt32(item["conversacion"]),
                        fecha_orden = Convert.ToDateTime(item["fecha_orden"]),
                        titular = (item["titular"]).ToString(),
                        tipo_orden = (item["tipo_orden"]).ToString(),
                        motivo_orden = (item["motivo_orden"]).ToString(),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString()
                    };
                    loc.Add(a);
                }
                return loc;
            }
            catch (Exception ex)
            {
                return loc;
            }
        }

        public Boolean Add(OCOrdenCompra dc)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_orden_insert]");
                consulta.AgregarParametro("@codigo_orden", dc.codigo_orden);
                consulta.AgregarParametro("@tipo_orden", dc.tipo_orden);
                consulta.AgregarParametro("@estado", dc.estado);
                consulta.AgregarParametro("@estado_transferencia", dc.estado_transferencia);
                consulta.AgregarParametro("@fecha_orden", DateTime.Now);
                consulta.AgregarParametro("@codigo_proveedor", dc.codigo_proveedor);
                consulta.AgregarParametro("@nombre_proveedor", dc.nombre_proveedor);
                consulta.AgregarParametro("@direccion_proveedor", dc.direccion_proveedor);
                consulta.AgregarParametro("@empid", dc.empid);
                consulta.AgregarParametro("@solicitante", dc.solicitante);
                consulta.AgregarParametro("@nombre_solicitante", dc.nombre_solicitante);
                consulta.AgregarParametro("@autorizador_sub", dc.autorizador_sub);
                consulta.AgregarParametro("@autorizador_gerencia", dc.autorizador_gerencia);
                consulta.AgregarParametro("@monto_total", dc.monto_total);
                consulta.AgregarParametro("@motivo_orden", dc.motivo_orden);
                consulta.AgregarParametro("@fecha_entrega", dc.fecha_entrega);
                consulta.AgregarParametro("@estado_autorizacion_subgerencia", "P");
                consulta.AgregarParametro("@motivo_autorizacion_subgerencia", dc.motivo_autorizacion_subgerencia);
                consulta.AgregarParametro("@fecha_autorizacion_subgerencia", DateTime.Now);
                consulta.AgregarParametro("@estado_autorizacion_gerencia", "P");
                consulta.AgregarParametro("@motivo_autorizacion_gerencia", dc.motivo_autorizacion_gerencia);
                consulta.AgregarParametro("@fecha_autorizacion_gerencia", DateTime.Now);
                consulta.AgregarParametro("@tipo_compra", dc.tipo_compra);
                consulta.AgregarParametro("@incoterms", dc.incoterms);
                consulta.AgregarParametro("@encargado_compra", dc.encargado_compra);
                consulta.AgregarParametro("@nombre_encargado_compra", dc.nombre_encargado_compra);
                consulta.AgregarParametro("@usuario_creacion", dc.usuario_creacion);
                consulta.AgregarParametro("@fecha_creacion", DateTime.Now);
                consulta.AgregarParametro("@usuario_modificacion", dc.usuario_modificacion);
                consulta.AgregarParametro("@fecha_modificacion", DateTime.Now);

                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
