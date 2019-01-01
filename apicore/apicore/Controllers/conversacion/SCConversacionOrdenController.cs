using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaNegocio;
using CapaModelos;

namespace apicore.Controllers.conversacion
{
    public class SCConversacionOrdenController : ApiController
    {
        SCConversacionNegocio cn = new SCConversacionNegocio();
        // GET api/scconversacionorden
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scconversacionorden/5
        public ResponseConversacion Get(string id)
        {
            List<Conversacion> lc = new List<Conversacion>();
            lc = cn.GetConversacionesXOrden(id);
            return new ResponseConversacion()
            {
                status = 200,
                body = lc,
                length = lc.Count,
                message = "OK"
            };
        }

        // POST api/scconversacionorden
        public ResponseAddConversacion Post([FromBody]Conversacion value)
        {
            if (cn.AddConversacionOrden(value))
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

        // PUT api/scconversacionorden/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scconversacionorden/5
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
