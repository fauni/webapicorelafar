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
    public class AutorizarSolicitudController : ApiController
    {
        SolicitudCompraNegocio sn = new SolicitudCompraNegocio();
        // GET api/autorizarsolicitud
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/autorizarsolicitud/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/autorizarsolicitud
        public ResponseAddSolicitud Post([FromBody]RequestAutorizacionSolicitud value)
        {
            if (sn.Autorizar(value))
            {
                return new ResponseAddSolicitud()
                {
                    status = 200,
                    message = "TRUE"
                };
            }
            else
            {
                return new ResponseAddSolicitud()
                {
                    status = 304,
                    message = "FALSE"
                };
            }
        }

        // PUT api/autorizarsolicitud/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/autorizarsolicitud/5
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
