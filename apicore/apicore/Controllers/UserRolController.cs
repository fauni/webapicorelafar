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
    public class UserRolController : ApiController
    {
        UserRolNegocio urn = new UserRolNegocio();
        // GET api/userrol
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/userrol/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/userrol
        public ResponseUserRol Post([FromBody]RequestUserApp value)
        {
            ResponseUserRol response = new ResponseUserRol();
            UserRol ura = new UserRol();
            ura = urn.GetUserRolApp(value);
            if(ura.id != null){
                response.length = 1;
            } else {
                response.length = 0;
            }
            response.status = 200;
            response.body = ura;
            response.message = "OK";
            return response;
        }

        // PUT api/userrol/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/userrol/5
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
