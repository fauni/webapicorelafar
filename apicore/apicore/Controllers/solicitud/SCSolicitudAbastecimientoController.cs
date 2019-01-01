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
    public class SCSolicitudAbastecimientoController : ApiController
    {
        SolicitudCompraNegocio sn = new SolicitudCompraNegocio();
        // GET api/scsolicitudabastecimiento
        public ResponseGetSolicitudesXUsuario Get()
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            lsolicitud = sn.GetSolicitudesXAbastecimiento();
            return new ResponseGetSolicitudesXUsuario
            {
                status = 200,
                body = lsolicitud,
                length = lsolicitud.Count,
                message = "OK"
            };
        }

        // GET api/scsolicitudabastecimiento/5
        public ResponseGetSolicitudesXUsuario Get(string id)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            lsolicitud = sn.GetSolicitudesXEstado(id);
            return new ResponseGetSolicitudesXUsuario
            {
                status = 200,
                body = lsolicitud,
                length = lsolicitud.Count,
                message = "OK"
            };
        }

        // POST api/scsolicitudabastecimiento
        public void Post([FromBody]string value)
        {

        }

        // PUT api/scsolicitudabastecimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scsolicitudabastecimiento/5
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
