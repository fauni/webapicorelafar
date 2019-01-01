using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using System.Data;
using System.Globalization;

namespace CapaNegocio
{
    public class SCDetalleOrdenCompraNegocio
    {
        
        public List<OCDetalleOrdenCompra> GetDetalleOrdenCompra(string codigo_orden)
        {
            List<OCDetalleOrdenCompra> ldoc = new List<OCDetalleOrdenCompra>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_detalle_orden_get]");
                consulta.AgregarParametro("@codigo_orden", codigo_orden);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    OCDetalleOrdenCompra a = new OCDetalleOrdenCompra
                    {
                        id_detalle_solicitud = Convert.ToInt32(item["id_detalle_solicitud"]),
                        codigo_solicitud = (item["codigo_solicitud"]).ToString(),
                        codigo_orden = (item["codigo_orden"]).ToString(),
                        codigo_item = (item["codigo_item"]).ToString(),
                        descripcion_item = (item["descripcion_item"]).ToString(),
                        tipo_item = (item["tipo_item"]).ToString(),
                        fecha_arte = Convert.ToDateTime(item["fecha_arte"]),
                        fecha_requerida = Convert.ToDateTime(item["fecha_requerida"]),
                        cantidad = Convert.ToSingle(item["cantidad"], CultureInfo.CreateSpecificCulture("es-ES")),
                        unidad = (item["unidad"]).ToString(),
                        precio_unitario = Convert.ToSingle(item["precio_unitario"], CultureInfo.CreateSpecificCulture("es-ES")),
                        sub_total = Convert.ToSingle(item["sub_total"], CultureInfo.CreateSpecificCulture("es-ES")),
                        estado = (item["estado"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString()
                    };
                    ldoc.Add(a);
                }
                return ldoc;
            }
            catch (Exception ex)
            {
                return ldoc;
            }
        }

        public Boolean Add(OCDetalleOrdenCompra doc)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_detalle_orden_insert]");
                consulta.AgregarParametro("@id_detalle_solicitud", doc.id_detalle_solicitud);
                consulta.AgregarParametro("@codigo_solicitud", doc.codigo_solicitud);
                consulta.AgregarParametro("@codigo_orden", doc.codigo_orden);
                consulta.AgregarParametro("@codigo_item", doc.codigo_item);
                consulta.AgregarParametro("@descripcion_item", doc.descripcion_item);
                consulta.AgregarParametro("@tipo_item", doc.tipo_item);
                consulta.AgregarParametro("@fecha_arte", doc.fecha_arte);
                consulta.AgregarParametro("@fecha_requerida", doc.fecha_requerida);
                consulta.AgregarParametro("@cantidad", doc.cantidad);
                consulta.AgregarParametro("@unidad", doc.unidad);
                consulta.AgregarParametro("@precio_unitario", doc.precio_unitario);
                consulta.AgregarParametro("@sub_total", doc.sub_total);
                consulta.AgregarParametro("@estado", doc.estado);
                consulta.AgregarParametro("@usuario_creacion", doc.usuario_creacion);
                consulta.AgregarParametro("@usuario_modificacion", doc.usuario_modificacion);

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
