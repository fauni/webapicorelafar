using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;
using Comunes;

namespace CapaNegocio
{
    public class NotificacionOrdenNegocio
    {
        SCOrdenCompraComunes comunes = new SCOrdenCompraComunes();
        public List<NotificacionOrden> GetSolicitantesOrden(string codigo_orden)
        {
            List<NotificacionOrden> ldoc = new List<NotificacionOrden>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_solicitantes_orden]");
                consulta.AgregarParametro("@codigo_orden", codigo_orden);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    NotificacionOrden a = new NotificacionOrden
                    {
                        codigo_solicitud = (item["codigo_solicitud"]).ToString(),
                        codigo_orden = (item["codigo_orden"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        autorizador = (item["autorizador"]).ToString()
                    };
                    ldoc.Add(a);

                    SCUsuarios solicitante = new SCUsuarios();
                    SCUsuarios autorizador = new SCUsuarios();
                    solicitante = new UsuariosNegocio().GetUsuariosPorUsername(a.solicitante);
                    autorizador = new UsuariosNegocio().GetUsuariosPorUsername(a.autorizador);

                    Email email = new Email();
                    email.From = "solicitudcompras@lafar.net";
                    email.To = "faruni@lafar.net"; //solicitante.email; // -- Colocar este valor en producción
                    email.Subject = "Sistema de Compras";
                    email.Body = comunes.bodyEmailNuevaOrden(solicitante, a); //"Se ha creado una nueva solicitud de compra para su autorización";

                    comunes.enviarEmail(email);
                }
                return ldoc;
            }
            catch (Exception ex)
            {
                return ldoc;
            }
        }

        public List<NotificacionOrden> GetSolicitantesOrden(OCOrdenCompra orden, string tipo_autorizacion_sg)
        {
            List<NotificacionOrden> ldoc = new List<NotificacionOrden>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_solicitantes_orden]");
                consulta.AgregarParametro("@codigo_orden", orden.codigo_orden);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    NotificacionOrden a = new NotificacionOrden
                    {
                        codigo_solicitud = (item["codigo_solicitud"]).ToString(),
                        codigo_orden = (item["codigo_orden"]).ToString(),
                        solicitante = (item["solicitante"]).ToString(),
                        autorizador = (item["autorizador"]).ToString()
                    };
                    ldoc.Add(a);

                    SCUsuarios solicitante = new SCUsuarios();
                    SCUsuarios autorizador = new SCUsuarios();
                    solicitante = new UsuariosNegocio().GetUsuariosPorUsername(a.solicitante);
                    autorizador = new UsuariosNegocio().GetUsuariosPorUsername(a.autorizador);

                    Email email = new Email();
                    email.From = "solicitudcompras@lafar.net";
                    email.To = "faruni@lafar.net"; //solicitante.email; // -- Colocar este valor en producción
                    email.Subject = "Sistema de Compras";

                    switch (tipo_autorizacion_sg)
                    {
                        case "X": 
                            email.Body = comunes.bodyEmailAnularOrden(solicitante, a, orden); //"Se ha creado una nueva solicitud de compra para su autorización";
                            break;
                        case "R":
                            email.Body = comunes.bodyEmailRechazarOrden(solicitante, a, orden);
                            break;
                        case "A":
                            email.Body = comunes.bodyEmailAprobarOrden(solicitante, a, orden);
                            break;
                    }

                    comunes.enviarEmail(email);
                }
                return ldoc;
            }
            catch (Exception ex)
            {
                return ldoc;
            }
        }
    }
}
