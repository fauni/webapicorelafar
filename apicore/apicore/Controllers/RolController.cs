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
    public class RolController : ApiController
    {
        ResponseRol response = new ResponseRol();
        RolNegocio rn = new RolNegocio();

        // GET api/rol
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/rol/5
        public ResponseRol Get(string id)
        {
            List<Rol> lrol = new List<Rol>();
            lrol = rn.GetListaRol(id);
            response.status = 200;
            response.body = lrol;
            response.length = lrol.Count;
            response.message = "OK";
            return response;
        }

        // POST api/rol
        public void Post([FromBody]string value)
        {
        }

        // PUT api/rol/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/rol/5
        public void Delete(int id)
        {
        }
    }
}
