using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaModelos;
using CapaNegocio;

namespace apicore.Controllers.conversacion
{
    public class SCConversacionSolicitudController : ApiController
    {
        SCConversacionNegocio cn = new SCConversacionNegocio();
        // GET api/scconversacionsolicitud
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scconversacionsolicitud/5
        public ResponseConversacion Get(string id)
        {
            List<Conversacion> lc = new List<Conversacion>();
            lc = cn.GetConversacionesXSolicitud(id);
            return new ResponseConversacion() { 
                status = 200,
                body = lc,
                length = lc.Count,
                message = "OK"
            };
        }

        // POST api/scconversacionsolicitud
        public ResponseAddConversacion Post([FromBody]Conversacion value)
        {
            if (cn.Add(value))
            {
                return new ResponseAddConversacion
                {
                    status = 200,
                    message = "OK"
                };
            }
            else
            {
                return new ResponseAddConversacion
                {
                    status = 303,
                    message = "NO"
                };
            }
        }

        // PUT api/scconversacionsolicitud/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scconversacionsolicitud/5
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
