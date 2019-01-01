using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaModelos;
using CapaNegocio;

namespace apicore.Controllers
{
    public class SCSolicitudAutorizadorController : ApiController
    {
        SolicitudCompraNegocio sn = new SolicitudCompraNegocio();
        // GET api/scsolicitudautorizador
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scsolicitudautorizador/5
        public ResponseGetSolicitudesXUsuario Get(string id)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            lsolicitud = sn.GetSolicitudesXSupervisor(id);
            return new ResponseGetSolicitudesXUsuario { 
                status = 200,
                body = lsolicitud,
                length = lsolicitud.Count,
                message = "OK" 
            };
        }

        // POST api/scsolicitudautorizador
        public ResponseGetSolicitudesXUsuario Post([FromBody]RequestEstadoAutorizador value)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            lsolicitud = sn.GetSolicitudesXEstadoForAutorizador(value);
            return new ResponseGetSolicitudesXUsuario
            {
                status = 200,
                body = lsolicitud,
                length = lsolicitud.Count,
                message = "OK"
            };
        }

        // PUT api/scsolicitudautorizador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scsolicitudautorizador/5
        public void Delete(int id)
        {
        }

        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
