using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaModelos;
using CapaNegocio;

namespace apicore.Controllers.orden
{
    public class AnularOrdenController : ApiController
    {
        SCOrdenCompraNegocio on = new SCOrdenCompraNegocio();
        // GET api/anularorden
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/anularorden/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/anularorden
        public ResponseAddSolicitud Post([FromBody]RequestAnulacionSolicitud value)
        {
            if (on.Anular(value))
            {
                return new ResponseAddSolicitud()
                {
                    status = 200,
                    message = "Se anulo la orden"
                };
            }
            else
            {
                return new ResponseAddSolicitud()
                {
                    status = 304,
                    message = "No se anulo la orden"
                };
            }
        }

        // PUT api/anularorden/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/anularorden/5
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
