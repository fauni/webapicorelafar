using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaNegocio;
using CapaModelos;

namespace apicore.Controllers.solicitud
{
    public class AnularSolicitudController : ApiController
    {
        SolicitudCompraNegocio sn = new SolicitudCompraNegocio();
        // GET api/anularsolicitud
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/anularsolicitud/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/anularsolicitud
        public ResponseAddSolicitud Post([FromBody]RequestAnulacionSolicitud value)
        {
            if (sn.Anular(value))
            {
                return new ResponseAddSolicitud()
                {
                    status = 200,
                    message = "Se anulo la solicitud"
                };
            }
            else
            {
                return new ResponseAddSolicitud()
                {
                    status = 304,
                    message = "No se anulo la solicitud"
                };
            }
        }

        // PUT api/anularsolicitud/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/anularsolicitud/5
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
