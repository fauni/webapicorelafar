using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;

namespace CapaNegocio
{
    public class SCConversacionNegocio
    {
        // Permite obtener las conversaciones realizadas por codigo de solicitud
        public List<Conversacion> GetConversacionesXSolicitud(string codigo_documento)
        {
            List<Conversacion> lconversacion = new List<Conversacion>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_conversacion_x_solicitud]");
                consulta.AgregarParametro("@codigo_documento", codigo_documento);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    Conversacion c = new Conversacion
                    {
                        id_conversacion = Convert.ToInt32(item["id_conversacion"]),
                        codigo_documento = (item["codigo_documento"]).ToString(),
                        username = (item["username"]).ToString(),
                        nombre_usuario = (item["nombre_usuario"]).ToString(),
                        fecha_hora = Convert.ToDateTime(item["fecha_hora"]),
                        mensaje = (item["mensaje"]).ToString(),
                        estado = (item["estado"]).ToString(),
                    };
                    lconversacion.Add(c);
                }
                return lconversacion;
            }
            catch (Exception ex)
            {
                return lconversacion;
            }
        }

        public Boolean Add(Conversacion c)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_insert_conversacion");
                consulta.AgregarParametro("@codigo_documento", c.codigo_documento);
                consulta.AgregarParametro("@username", c.username);
                consulta.AgregarParametro("@nombre_usuario", c.nombre_usuario);
                consulta.AgregarParametro("@mensaje", c.mensaje);
                consulta.AgregarParametro("@estado", c.estado);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Permite obtener las conversaciones realizadas por codigo de solicitud
        public List<Conversacion> GetConversacionesXOrden(string codigo_documento)
        {
            List<Conversacion> lconversacion = new List<Conversacion>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_conversacion_x_orden]");
                consulta.AgregarParametro("@codigo_documento", codigo_documento);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    Conversacion c = new Conversacion
                    {
                        id_conversacion = Convert.ToInt32(item["id_conversacion"]),
                        codigo_documento = (item["codigo_documento"]).ToString(),
                        username = (item["username"]).ToString(),
                        nombre_usuario = (item["nombre_usuario"]).ToString(),
                        fecha_hora = Convert.ToDateTime(item["fecha_hora"]),
                        mensaje = (item["mensaje"]).ToString(),
                        estado = (item["estado"]).ToString(),
                    };
                    lconversacion.Add(c);
                }
                return lconversacion;
            }
            catch (Exception ex)
            {
                return lconversacion;
            }
        }

        public Boolean AddConversacionOrden(Conversacion c)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_insert_conversacion_orden");
                consulta.AgregarParametro("@codigo_documento", c.codigo_documento);
                consulta.AgregarParametro("@username", c.username);
                consulta.AgregarParametro("@nombre_usuario", c.nombre_usuario);
                consulta.AgregarParametro("@mensaje", c.mensaje);
                consulta.AgregarParametro("@estado", c.estado);
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
