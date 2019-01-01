using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using CapaDatos;
using System.Data;
using System.Globalization;

namespace CapaNegocio
{
    public class SCDetalleSolicitudCompraNegocio
    {
        public List<DetalleSolicitudCompraSC> GetDetalleSolicitudXCodigo(string codigo)
        {
            List<DetalleSolicitudCompraSC> ldetallesolicitud = new List<DetalleSolicitudCompraSC>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_detalle_solicitud_codigo]");
                consulta.AgregarParametro("@codigo", codigo);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    DetalleSolicitudCompraSC scl = new DetalleSolicitudCompraSC
                    {
                        id_detalle_solicitud = Convert.ToInt32(item["id_detalle_solicitud"]),
                        codigo_solicitud = (item["codigo_solicitud"]).ToString(),
                        codigo_item = (item["codigo_item"]).ToString(),
                        descripcion_item = (item["descripcion_item"]).ToString(),
                        tipo_item = (item["tipo_item"]).ToString(),
                        fecha_arte = Convert.ToDateTime(item["fecha_arte"]),
                        fecha_requerida = Convert.ToDateTime(item["fecha_requerida"]),
                        cantidad = Convert.ToSingle(item["cantidad"], CultureInfo.CreateSpecificCulture("es-ES")),
                        unidad = (item["unidad"]).ToString(),
                        prioridad = Convert.ToInt32(item["prioridad"]),
                        estado = (item["estado"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    ldetallesolicitud.Add(scl);
                }
                return ldetallesolicitud;
            }
            catch (Exception ex)
            {
                return ldetallesolicitud;
            }
        }

        public Boolean Add(DetalleSolicitudCompraSC dc)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_detalle_solicitud_insert]");
                consulta.AgregarParametro("@codigo_solicitud",dc.codigo_solicitud);
	            consulta.AgregarParametro("@codigo_item",dc.codigo_item);
	            consulta.AgregarParametro("@descripcion_item",dc.descripcion_item);
	            consulta.AgregarParametro("@tipo_item",dc.tipo_item);
                consulta.AgregarParametro("@fecha_arte", dc.fecha_arte);
	            consulta.AgregarParametro("@fecha_requerida",dc.fecha_requerida);
	            consulta.AgregarParametro("@cantidad",dc.cantidad);
	            consulta.AgregarParametro("@unidad",dc.unidad);
	            consulta.AgregarParametro("@prioridad",dc.prioridad);
	            consulta.AgregarParametro("@estado",dc.estado);
	            consulta.AgregarParametro("@usuario_creacion",dc.usuario_creacion);
	            consulta.AgregarParametro("@fecha_creacion",DateTime.Now);
	            consulta.AgregarParametro("@usuario_modificacion",dc.usuario_modificacion);
	            consulta.AgregarParametro("@fecha_modificacion", DateTime.Now);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region MODIFICAR ESTADO DETALLE DE LA SOLICITUD
        public Boolean UpdateEstado(RequestUpdateEstadoDetalleSolicitudCompra dc)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_update_estado_detalle_solicitud]");
                consulta.AgregarParametro("@codigo_solicitud", dc.codigo_solicitud);
                consulta.AgregarParametro("@id_detalle_solicitud", dc.id_detalle_solicitud);
                consulta.AgregarParametro("@usuario_modificacion", dc.usuario_modificacion);
                consulta.AgregarParametro("@estado", dc.estado);

                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
