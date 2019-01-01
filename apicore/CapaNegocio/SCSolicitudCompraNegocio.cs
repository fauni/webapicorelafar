using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;
using CapaDatos;
using Comunes;

namespace CapaNegocio
{
    public class SolicitudCompraNegocio
    {
        // Esta funcion permite obtener el listado de las solicitudes por usuario
        public List<Solicitudcompralistado> GetSolicitudesXUsuario(string username)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_solicitante_select]");
                consulta.AgregarParametro("@solicitante", username);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                ConsultaMySql consultaMYS = new ConsultaMySql(@"select * from newlafarnet.users");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dtMYS = consultaMYS.EjecutarConsulta(Parametros.ConexionBDMySQL());
                DataView view = dtMYS.AsDataView();

                foreach (DataRow item in dt.Rows)
                {
                    view.RowFilter = "username= '" + item["solicitante"].ToString() + "'";

                    Solicitudcompralistado scl = new Solicitudcompralistado
                    {
                        codigo = (item["codigo"]).ToString(),
                        conversacion = Convert.ToInt32(item["conversacion"]),
                        tipo = (item["tipo"]).ToString(),
                        fecha = Convert.ToDateTime(item["fecha"]),
                        motivo = (item["motivo"]).ToString(),
                        estado_autorizacion_superior = (item["estado_autorizacion_superior"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        nombre_solicitante = view[0][1].ToString() + " " + view[0][2].ToString()
                    };
                    lsolicitud.Add(scl);
                }
                return lsolicitud;
            }
            catch (Exception ex)
            {
                return lsolicitud;
            }
        }

        // Esta funcion permite obtener el listado de las solicitudes por autorizador
        public List<Solicitudcompralistado> GetSolicitudesXSupervisor(string autorizador)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_autorizador_select]");
                consulta.AgregarParametro("@autorizador", autorizador);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                ConsultaMySql consultaMYS = new ConsultaMySql(@"select * from newlafarnet.users");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dtMYS = consultaMYS.EjecutarConsulta(Parametros.ConexionBDMySQL());
                DataView view = dtMYS.AsDataView();

                foreach (DataRow item in dt.Rows)
                {
                    view.RowFilter = "username= '" + item["solicitante"].ToString() + "'";
                    Solicitudcompralistado scl = new Solicitudcompralistado
                    {
                        codigo = (item["codigo"]).ToString(),
                        conversacion = Convert.ToInt32(item["conversacion"]),
                        tipo = (item["tipo"]).ToString(),
                        fecha = Convert.ToDateTime(item["fecha"]),
                        motivo = (item["motivo"]).ToString(),
                        estado_autorizacion_superior = (item["estado_autorizacion_superior"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        nombre_solicitante = view[0][1].ToString() + " " + view[0][2].ToString()
                    };
                    lsolicitud.Add(scl);
                }
                return lsolicitud;
            }
            catch (Exception ex)
            {
                return lsolicitud;
            }
        }

        // Esta funcion permite obtener el listado de las solicitudes para abastecimiento
        public List<Solicitudcompralistado> GetSolicitudesXAbastecimiento()
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_abastecimiento_select]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                ConsultaMySql consultaMYS = new ConsultaMySql(@"select * from newlafarnet.users");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dtMYS = consultaMYS.EjecutarConsulta(Parametros.ConexionBDMySQL());
                DataView view = dtMYS.AsDataView();

                foreach (DataRow item in dt.Rows)
                {
                    view.RowFilter = "username= '" + item["solicitante"].ToString() + "'";
                    Solicitudcompralistado scl = new Solicitudcompralistado
                    {
                        codigo = (item["codigo"]).ToString(),
                        conversacion = Convert.ToInt32(item["conversacion"]),
                        tipo = (item["tipo"]).ToString(),
                        fecha = Convert.ToDateTime(item["fecha"]),
                        motivo = (item["motivo"]).ToString(),
                        estado_autorizacion_superior = (item["estado_autorizacion_superior"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        nombre_solicitante = view[0][1].ToString() + " " + view[0][2].ToString()
                    };
                    lsolicitud.Add(scl);
                }
                return lsolicitud;
            }
            catch (Exception ex)
            {
                return lsolicitud;
            }
        }

        // Esta funcion permite obtener el listado de las solicitudes para abastecimiento por estado
        public List<Solicitudcompralistado> GetSolicitudesXEstado(string estado)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();

            try
            {
                CapaDatos.StoreProcedure consulta;
                switch (estado)
                {
                    case "A":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_abastecimiento_select_autorizadas]");
                        break;
                    case "R":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_abastecimiento_select_rechazadas]");
                        break;
                    case "X":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_abastecimiento_select_anuladas]");
                        break;
                    case "T":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_abastecimiento_select]");
                        break;
                    case "P":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_abastecimiento_select_pendientes]");
                        break;
                    default:
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_abastecimiento_select]");
                        break;
                }

                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                ConsultaMySql consultaMYS = new ConsultaMySql(@"select * from newlafarnet.users");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dtMYS = consultaMYS.EjecutarConsulta(Parametros.ConexionBDMySQL());
                DataView view = dtMYS.AsDataView();

                foreach (DataRow item in dt.Rows)
                {
                    view.RowFilter = "username= '" + item["solicitante"].ToString() + "'";
                    Solicitudcompralistado scl = new Solicitudcompralistado
                    {
                        codigo = (item["codigo"]).ToString(),
                        conversacion = Convert.ToInt32(item["conversacion"]),
                        tipo = (item["tipo"]).ToString(),
                        fecha = Convert.ToDateTime(item["fecha"]),
                        motivo = (item["motivo"]).ToString(),
                        estado_autorizacion_superior = (item["estado_autorizacion_superior"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        nombre_solicitante = view[0][1].ToString() + " " + view[0][2].ToString()
                    };
                    lsolicitud.Add(scl);
                }
                return lsolicitud;
            }
            catch (Exception ex)
            {
                return lsolicitud;
            }
        }

        // Funcion para obtener listado de solicitudes por estado para los autorizadores
        public List<Solicitudcompralistado> GetSolicitudesXEstadoForAutorizador(RequestEstadoAutorizador estado)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();

            try
            {
                CapaDatos.StoreProcedure consulta;
                switch (estado.estado_autorizacion)
                {
                    case "A":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_autorizador_select_autorizadas]");
                        break;
                    case "R":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_autorizador_select_rechazadas]");
                        break;
                    case "X":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_autorizador_select_anuladas]");
                        break;
                    case "T":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_autorizador_select]");
                        break;
                    case "P":
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_autorizador_select_pendientes]");
                        break;
                    default:
                        consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_autorizador_select]");
                        break;
                }
                consulta.AgregarParametro("@autorizador", estado.id_superior);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                ConsultaMySql consultaMYS = new ConsultaMySql(@"select * from newlafarnet.users");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dtMYS = consultaMYS.EjecutarConsulta(Parametros.ConexionBDMySQL());
                DataView view = dtMYS.AsDataView();

                foreach (DataRow item in dt.Rows)
                {
                    view.RowFilter = "username= '" + item["solicitante"].ToString() + "'";
                    Solicitudcompralistado scl = new Solicitudcompralistado
                    {
                        codigo = (item["codigo"]).ToString(),
                        conversacion = Convert.ToInt32(item["conversacion"]),
                        tipo = (item["tipo"]).ToString(),
                        fecha = Convert.ToDateTime(item["fecha"]),
                        motivo = (item["motivo"]).ToString(),
                        estado_autorizacion_superior = (item["estado_autorizacion_superior"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        nombre_solicitante = view[0][1].ToString() + " " + view[0][2].ToString()
                    };
                    lsolicitud.Add(scl);
                }
                return lsolicitud;
            }
            catch (Exception ex)
            {
                return lsolicitud;
            }
        }
        // Esta funcion permite obtener una solicitud por su codigo
        public SolicitudCompra GetSolicitudXCodigo(string codigo)
        {
            SolicitudCompra sc = new SolicitudCompra();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_solicitud_por_codigo]");
                consulta.AgregarParametro("@codigo", codigo);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    SolicitudCompra scaux = new SolicitudCompra
                    {
                        id = Convert.ToInt32(item["id"]), 
                        codigo = (item["codigo"]).ToString(),
                        tipo = (item["tipo"]).ToString(),
                        estado = (item["estado"]).ToString(),
                        estado_transferencia = (item["estado"]).ToString(),
                        fecha = Convert.ToDateTime(item["fecha"]),
                        motivo = (item["motivo"]).ToString(),
                        usuario_anulacion = (item["usuario_anulacion"]).ToString(),
                        motivo_anulacion = (item["motivo_anulacion"]).ToString(),
                        fecha_anulacion = Convert.ToDateTime(item["fecha_anulacion"]),
                        solicitante = (item["solicitante"]).ToString(),
                        autorizador = (item["autorizador"]).ToString(),
                        estado_autorizacion_superior = (item["estado_autorizacion_superior"]).ToString(),
                        fecha_autorizacion_superior = Convert.ToDateTime(item["fecha_autorizacion_superior"]),
                        motivo_autorizacion = (item["motivo_autorizacion"]).ToString(),
                        tipo_compra = (item["tipo_compra"]).ToString(),
                        codigo_proveedor = (item["codigo_proveedor"]).ToString(),
                        nombre_proveedor = (item["nombre_proveedor"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    sc = scaux;
                }
                return sc;
            }
            catch (Exception ex)
            {
                return sc;
            }
        }

        public Boolean Add(SolicitudCompra s)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_solicitud_insert");
                consulta.AgregarParametro("@codigo", s.codigo);
                consulta.AgregarParametro("@tipo", s.tipo);
                consulta.AgregarParametro("@estado", s.estado);
                consulta.AgregarParametro("@estado_transferencia", s.estado_transferencia);
                consulta.AgregarParametro("@fecha", DateTime.Now);
                consulta.AgregarParametro("@motivo", s.motivo);
                consulta.AgregarParametro("@usuario_anulacion", s.usuario_anulacion);
                consulta.AgregarParametro("@motivo_anulacion", s.motivo_anulacion);
                consulta.AgregarParametro("@fecha_anulacion", DateTime.Now);
                consulta.AgregarParametro("@solicitante", s.solicitante);
                consulta.AgregarParametro("@autorizador", s.autorizador);
                consulta.AgregarParametro("@estado_autorizacion_superior", s.estado_autorizacion_superior);
                consulta.AgregarParametro("@fecha_autorizacion_superior", DateTime.Now);
                consulta.AgregarParametro("@motivo_autorizacion", s.motivo_autorizacion);
                consulta.AgregarParametro("@tipo_compra", s.tipo_compra);
                consulta.AgregarParametro("@codigo_proveedor", s.codigo_proveedor);
                consulta.AgregarParametro("@nombre_proveedor", s.nombre_proveedor);
                consulta.AgregarParametro("@usuario_creacion", s.usuario_creacion);
                consulta.AgregarParametro("@fecha_creacion", DateTime.Now);
                consulta.AgregarParametro("@usuario_modificacion", s.usuario_modificacion);
                consulta.AgregarParametro("@fecha_modificacion", DateTime.Now);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                SCUsuarios solicitante = new SCUsuarios();
                SCUsuarios autorizador = new SCUsuarios();
                solicitante = new UsuariosNegocio().GetUsuariosPorUsername(s.solicitante);
                autorizador = new UsuariosNegocio().GetUsuariosPorUsername(s.autorizador);

                SCSolicitudCompraComunes comunes = new SCSolicitudCompraComunes();

                Email email =  new Email();
                email.From = solicitante.email;
                email.To = "faruni@lafar.net"; // autorizador.email;  -- Colocar este valor en producción
                email.Subject = "Solicitud de Compra";
                email.Body = comunes.bodyEmailNuevaSolicitud(autorizador, solicitante, s.codigo); //"Se ha creado una nueva solicitud de compra para su autorización";
                
                comunes.enviarEmail(email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean Edit(SolicitudCompra s)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_solicitud_insert");
                consulta.AgregarParametro("@codigo", s.codigo);
                consulta.AgregarParametro("@tipo", s.tipo);
                consulta.AgregarParametro("@estado", s.estado);
                consulta.AgregarParametro("@estado_transferencia", s.estado_transferencia);
                consulta.AgregarParametro("@fecha", DateTime.Now);
                consulta.AgregarParametro("@motivo", s.motivo);
                consulta.AgregarParametro("@usuario_anulacion", s.usuario_anulacion);
                consulta.AgregarParametro("@motivo_anulacion", s.motivo_anulacion);
                consulta.AgregarParametro("@fecha_anulacion", DateTime.Now);
                consulta.AgregarParametro("@solicitante", s.solicitante);
                consulta.AgregarParametro("@autorizador", s.autorizador);
                consulta.AgregarParametro("@estado_autorizacion_superior", s.estado_autorizacion_superior);
                consulta.AgregarParametro("@fecha_autorizacion_superior", DateTime.Now);
                consulta.AgregarParametro("@motivo_autorizacion", s.motivo_autorizacion);
                consulta.AgregarParametro("@tipo_compra", s.tipo_compra);
                consulta.AgregarParametro("@codigo_proveedor", s.codigo_proveedor);
                consulta.AgregarParametro("@nombre_proveedor", s.nombre_proveedor);
                consulta.AgregarParametro("@usuario_creacion", s.usuario_creacion);
                consulta.AgregarParametro("@fecha_creacion", s.fecha_creacion);
                consulta.AgregarParametro("@usuario_modificacion", s.usuario_modificacion);
                consulta.AgregarParametro("@fecha_modificacion", DateTime.Now);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean Delete(string codigo_solicitud)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_eliminar_solicitud]");
                consulta.AgregarParametro("@codigo_solicitud", codigo_solicitud);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region FUNCIONES PARA AUTORIZACION DE SOLICITUD
        public Boolean Anular(RequestAnulacionSolicitud s)
        {
            try
            {
                CapaDatos.StoreProcedure consultaMS = new CapaDatos.StoreProcedure("sp_anular_solicitud");
                consultaMS.AgregarParametro("@codigo_solicitud", s.codigo_solicitud);
                consultaMS.AgregarParametro("@motivo_anulacion", s.motivo_anulacion);
                consultaMS.AgregarParametro("@usuario_anulacion", s.usuario_anulacion);
                DataTable dtMS = consultaMS.RealizarConsulta(Parametros.ConexionBDSAP());

                SolicitudCompra sc = new SolicitudCompra();
                sc = this.GetSolicitudXCodigo(s.codigo_solicitud);

                SCUsuarios solicitante = new SCUsuarios();
                SCUsuarios anulador = new SCUsuarios();

                solicitante = new UsuariosNegocio().GetUsuariosPorUsername(sc.solicitante);
                anulador = new UsuariosNegocio().GetUsuariosPorUsername(s.usuario_anulacion);

                SCSolicitudCompraComunes comunes = new SCSolicitudCompraComunes();

                Email email = new Email();
                email.From = anulador.email;
                email.To = "faruni@lafar.net"; //  solicitante.email;  // -- Colocar este valor en producción
                email.Subject = "Solicitud de Compra Anulada";
                email.Body = comunes.bodyEmailAnularSolicitud(anulador, solicitante, s.codigo_solicitud, s.motivo_anulacion); //"Se ha anulado una solicitud"

                comunes.enviarEmail(email);

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
                CapaDatos.StoreProcedure consultaMS = new CapaDatos.StoreProcedure("sp_aprobar_o_rechazar_solicitud");
                consultaMS.AgregarParametro("@codigo_solicitud", s.codigo_solicitud);
                consultaMS.AgregarParametro("@motivo_autorizacion_superior", s.motivo_autorizacion_superior);
                consultaMS.AgregarParametro("@estado_autorizacion", s.estado_autorizacion);
                consultaMS.AgregarParametro("@autorizador", s.autorizador);
                DataTable dtMS = consultaMS.RealizarConsulta(Parametros.ConexionBDSAP());

                SolicitudCompra sc = new SolicitudCompra();
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

                comunes.enviarEmail(email);
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
