using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using System.Data;
using System.Globalization;
using CapaDatos;
using Comunes;

namespace CapaNegocio
{
    public class SCOrdenCompraNegocio
    {
        NotificacionOrdenNegocio nn = new NotificacionOrdenNegocio();
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
                        usuario_anulacion = (item["usuario_anulacion"]).ToString(),
                        motivo_anulacion = (item["motivo_anulacion"]).ToString(),
                        fecha_anulacion = Convert.ToDateTime(item["fecha_anulacion"]),
                        usuario_cierre = (item["usuario_cierre"]).ToString(),
                        fecha_cierre = Convert.ToDateTime(item["fecha_cierre"]),
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

        // Listado de Ordenes de Compra que no fueron descargados en archivo plano
        public List<OCOrdenCompraX> GetListaOrdenCompraSinSubir()
        {
            List<OCOrdenCompraX> lorden = new List<OCOrdenCompraX>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_lista_orden]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    OCOrdenCompraX a = new OCOrdenCompraX
                    {
                        id_orden_compra = (item["id_orden_compra"]).ToString(),
                        codigo_orden = (item["codigo_orden"]).ToString(),
                        tipo_orden = (item["tipo_orden"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        estado_transferencia = (item["estado_transferencia"]).ToString(),
                        fecha_orden = (item["fecha_orden"]).ToString(),
                        codigo_proveedor = (item["codigo_proveedor"]).ToString(),
                        nombre_proveedor = (item["nombre_proveedor"]).ToString(),
                        direccion_proveedor = (item["direccion_proveedor"]).ToString(),
                        empid = (item["empid"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        nombre_solicitante = (item["nombre_solicitante"]).ToString(),
                        autorizador_sub = (item["autorizador_sub"]).ToString(),
                        autorizador_gerencia = (item["autorizador_gerencia"]).ToString(),
                        monto_total = (item["monto_total"]).ToString(),
                        motivo_orden = (item["motivo_orden"]).ToString(),
                        fecha_entrega = (item["fecha_entrega"]).ToString(),
                        estado_autorizacion_subgerencia = (item["estado_autorizacion_subgerencia"]).ToString(),
                        motivo_autorizacion_subgerencia = (item["motivo_autorizacion_subgerencia"]).ToString(),
                        fecha_autorizacion_subgerencia = (item["fecha_autorizacion_subgerencia"]).ToString(),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString(),
                        motivo_autorizacion_gerencia = (item["motivo_autorizacion_gerencia"]).ToString(),
                        fecha_autorizacion_gerencia = (item["fecha_autorizacion_gerencia"]).ToString(),
                        tipo_compra = (item["tipo_compra"]).ToString(),
                        incoterms = (item["incoterms"]).ToString(),
                        encargado_compra = (item["encargado_compra"]).ToString(),
                        nombre_encargado_compra = (item["nombre_encargado_compra"]).ToString(),
                        usuario_anulacion = (item["usuario_anulacion"]).ToString(),
                        motivo_anulacion = (item["motivo_anulacion"]).ToString(),
                        fecha_anulacion = (item["fecha_anulacion"]).ToString(),
                        usuario_cierre = (item["usuario_cierre"]).ToString(),
                        fecha_cierre = (item["fecha_cierre"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = (item["fecha_creacion"]).ToString(),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = (item["fecha_modificacion"]).ToString()
                    };
                    lorden.Add(a);
                }
                return lorden;
            }
            catch (Exception ex)
            {
                return lorden;
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
                        estado_autorizacion_subgerencia = (item["estado_autorizacion_subgerencia"]).ToString(),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString(),
                        monto_total = Convert.ToSingle(item["monto_total"], CultureInfo.CreateSpecificCulture("es-ES")),
                        estado_transferencia = (item["estado_transferencia"]).ToString()

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

        public List<OrdenCompraListAbastecimiento> GetOrdenesComprasXAutorizador(string username)
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
                        estado_autorizacion_subgerencia = (item["estado_autorizacion_subgerencia"]).ToString(),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString(),
                        monto_total = Convert.ToSingle(item["monto_total"], CultureInfo.CreateSpecificCulture("es-ES")),
                        estado_transferencia = (item["estado_transferencia"]).ToString()

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

        public Boolean Edit(OCOrdenCompra dc)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_orden_insert]");
                consulta.AgregarParametro("@codigo_orden", dc.codigo_orden);
                consulta.AgregarParametro("@tipo_orden", dc.tipo_orden);
                consulta.AgregarParametro("@estado", dc.estado);
                consulta.AgregarParametro("@estado_transferencia", dc.estado_transferencia);
                consulta.AgregarParametro("@fecha_orden", dc.fecha_orden);
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
                consulta.AgregarParametro("@estado_autorizacion_subgerencia", dc.estado_autorizacion_subgerencia);
                consulta.AgregarParametro("@motivo_autorizacion_subgerencia", dc.motivo_autorizacion_subgerencia);
                consulta.AgregarParametro("@fecha_autorizacion_subgerencia", dc.fecha_autorizacion_subgerencia);
                consulta.AgregarParametro("@estado_autorizacion_gerencia", dc.estado_autorizacion_gerencia);
                consulta.AgregarParametro("@motivo_autorizacion_gerencia", dc.motivo_autorizacion_gerencia);
                consulta.AgregarParametro("@fecha_autorizacion_gerencia", dc.fecha_autorizacion_gerencia);
                consulta.AgregarParametro("@tipo_compra", dc.tipo_compra);
                consulta.AgregarParametro("@incoterms", dc.incoterms);
                consulta.AgregarParametro("@encargado_compra", dc.encargado_compra);
                consulta.AgregarParametro("@nombre_encargado_compra", dc.nombre_encargado_compra);
                consulta.AgregarParametro("@usuario_creacion", dc.usuario_creacion);
                consulta.AgregarParametro("@fecha_creacion", dc.fecha_creacion);
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

        public Boolean Delete(string oc)
        {
            string data = oc;
            string[] datos = data.Split('_');
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_eliminar_orden_compra]");
                consulta.AgregarParametro("@codigo_orden", datos[0]);
                consulta.AgregarParametro("@usuario_modificacion", datos[1]);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region FUNCIONES PARA AUTORIZACION DE ORDEN
        public Boolean Anular(RequestAnulacionSolicitud s)
        {
            try
            {
                CapaDatos.StoreProcedure consultaMS = new CapaDatos.StoreProcedure("sp_anular_orden");
                consultaMS.AgregarParametro("@codigo_orden", s.codigo_solicitud);
                consultaMS.AgregarParametro("@motivo_anulacion", s.motivo_anulacion);
                consultaMS.AgregarParametro("@usuario_anulacion", s.usuario_anulacion);
                DataTable dtMS = consultaMS.RealizarConsulta(Parametros.ConexionBDSAP());

                OCOrdenCompra oc = new OCOrdenCompra();
                List<NotificacionOrden> ls = new List<NotificacionOrden>();
                oc = this.GetOrdenCompra(s.codigo_solicitud);
                ls = nn.GetSolicitantesOrden(oc, "X");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean Autorizar(RequestAutorizacionSolicitud s)
        {
            if (s.motivo_autorizacion_superior == null)
            {
                s.motivo_autorizacion_superior = "NA";
            }
            try
            {
                CapaDatos.StoreProcedure consultaMS = new CapaDatos.StoreProcedure("sp_aprobar_o_rechazar_orden_subgerencia");
                consultaMS.AgregarParametro("@codigo_orden", s.codigo_solicitud);
                consultaMS.AgregarParametro("@motivo_autorizacion_subgerencia", s.motivo_autorizacion_superior);
                consultaMS.AgregarParametro("@estado_autorizacion_subgerencia", s.estado_autorizacion);
                consultaMS.AgregarParametro("@autorizador_sub", s.autorizador);
                DataTable dtMS = consultaMS.RealizarConsulta(Parametros.ConexionBDSAP());

                OCOrdenCompra oc = new OCOrdenCompra();
                List<NotificacionOrden> ls = new List<NotificacionOrden>();
                oc = this.GetOrdenCompra(s.codigo_solicitud);
                ls = nn.GetSolicitantesOrden(oc, s.estado_autorizacion);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean AutorizarG(RequestAutorizacionSolicitud s)
        {
            if (s.motivo_autorizacion_superior == null)
            {
                s.motivo_autorizacion_superior = "NA";
            }
            try
            {
                CapaDatos.StoreProcedure consultaMS = new CapaDatos.StoreProcedure("sp_aprobar_o_rechazar_orden_gerencia");
                consultaMS.AgregarParametro("@codigo_orden", s.codigo_solicitud);
                consultaMS.AgregarParametro("@motivo_autorizacion_subgerencia", s.motivo_autorizacion_superior);
                consultaMS.AgregarParametro("@estado_autorizacion_subgerencia", s.estado_autorizacion);
                consultaMS.AgregarParametro("@autorizador_sub", s.autorizador);
                DataTable dtMS = consultaMS.RealizarConsulta(Parametros.ConexionBDSAP());

                /* SolicitudCompra sc = new SolicitudCompra();
                sc = this.GetSolicitudXCodigo(s.codigo_solicitud);

                SCUsuarios solicitante = new SCUsuarios();
                SCUsuarios autorizador = new SCUsuarios();

                solicitante = new UsuariosNegocio().GetUsuariosPorUsername(sc.solicitante);
                autorizador = new UsuariosNegocio().GetUsuariosPorUsername(s.autorizador);

                SCSolicitudCompraComunes comunes = new SCSolicitudCompraComunes();

                Email email = new Email();
                email.From = autorizador.email;
                email.To = "faruni@lafar.net"; // solicitante.email;  // -- Colocar este valor en producción

                if (s.estado_autorizacion == "A")
                {
                    email.Subject = "Solicitud de Compra Aprobada";
                    email.Body = comunes.bodyEmailAprobarSolicitud(autorizador, solicitante, s.codigo_solicitud); //"Se ha anulado una solicitud"
                }
                else
                {
                    email.Subject = "Solicitud de Compra Rechazada";
                    email.Body = comunes.bodyEmailRechazarSolicitud(autorizador, solicitante, s.codigo_solicitud, s.motivo_autorizacion_superior); //"Se ha anulado una solicitud"
                }

                comunes.enviarEmail(email); */
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region LISTADO POR ESTADOS PARA ABASTECIMIENTO

        // Esta funcion permite obtener el listado de las ordenes para abastecimiento
        public List<OrdenCompraListAbastecimiento> GetListadoOrdenPorEstadoAbastecimiento(string estado)
        {
            List<OrdenCompraListAbastecimiento> loc = new List<OrdenCompraListAbastecimiento>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_listado_orden_x_estado_abastecimiento]");
                consulta.AgregarParametro("@estado_autorizacion_subgerencia", estado);
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
                        estado_autorizacion_subgerencia = (item["estado_autorizacion_subgerencia"]).ToString(),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString(),
                        monto_total = Convert.ToSingle(item["monto_total"], CultureInfo.CreateSpecificCulture("es-ES")),
                        estado_transferencia = (item["estado_transferencia"]).ToString()

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
        #endregion

        #region LISTADO POR ESTADOS PARA AUTORIZADORES

        // Esta funcion permite obtener el listado de las ordenes para AUTORIZADORES
        public List<OrdenCompraListAbastecimiento> GetListadoOrdenPorAutorizador(string autorizador)
        {
            List<OrdenCompraListAbastecimiento> loc = new List<OrdenCompraListAbastecimiento>();
            try
            {
                string[] separadas;
                separadas = autorizador.Split('_');
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_listado_orden_x_autorizador]");
                consulta.AgregarParametro("@username", separadas[0]);
                consulta.AgregarParametro("@estado_autorizacion_subgerencia", separadas[1]);
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
                        estado_autorizacion_subgerencia = (item["estado_autorizacion_subgerencia"]).ToString(),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString(),
                        monto_total = Convert.ToSingle(item["monto_total"], CultureInfo.CreateSpecificCulture("es-ES"))
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
        #endregion

        #region LISTADO POR ESTADOS PARA GERENCIA

        // Esta funcion permite obtener el listado de las ordenes para GERENCIA
        public List<OrdenCompraListAbastecimiento> GetListadoOrdenPorAutorizadorGerencia(string autorizador)
        {
            List<OrdenCompraListAbastecimiento> loc = new List<OrdenCompraListAbastecimiento>();
            try
            {
                string[] separadas;
                separadas = autorizador.Split('_');
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_listado_orden_x_autorizador_gerencia]");
                consulta.AgregarParametro("@username", separadas[0]);
                consulta.AgregarParametro("@estado_autorizacion_subgerencia", separadas[1]);
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
                        estado_autorizacion_subgerencia = (item["estado_autorizacion_subgerencia"]).ToString(),
                        estado_autorizacion_gerencia = (item["estado_autorizacion_gerencia"]).ToString(),
                        monto_total = Convert.ToSingle(item["monto_total"], CultureInfo.CreateSpecificCulture("es-ES"))
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
        #endregion
    }
}