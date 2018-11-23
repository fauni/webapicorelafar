using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaNegocio;
using CapaModelos;

namespace apicore.Controllers
{
    public class DepartamentoController : ApiController
    {
        DepartamentoNegocio dn = new DepartamentoNegocio();
        // GET api/departamento
        public ResponseDepartamento Get()
        {
            ResponseDepartamento r = new ResponseDepartamento();
            List<Departamento> ld = new List<Departamento>();
            ld = dn.GetListaDepartamentos();
            return new ResponseDepartamento {
                status = 200,
                body = ld,
                length = ld.Count,
                message = "OK"
            };
        }

        // GET api/departamento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/departamento
        public void Post([FromBody]string value)
        {
        }

        // PUT api/departamento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/departamento/5
        public void Delete(int id)
        {
        }
    }
}
