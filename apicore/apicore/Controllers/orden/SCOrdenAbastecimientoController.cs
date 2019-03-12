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
    public class SCOrdenAbastecimientoController : ApiController
    {
        SCOrdenCompraNegocio on = new SCOrdenCompraNegocio();
        // GET api/scordenabastecimiento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scordenabastecimiento/5
        public ResponseListadoOrdenCompraAbastecimiento Get(string id)
        {
            List<OrdenCompraListAbastecimiento> lorden = new List<OrdenCompraListAbastecimiento>();
            lorden = on.GetListadoOrdenPorEstadoAbastecimiento(id);
            return new ResponseListadoOrdenCompraAbastecimiento
            {
                status = 200,
                body = lorden,
                length = lorden.Count,
                message = "OK"
            };
        }

        // POST api/scordenabastecimiento
        public void Post([FromBody]string value)
        {
        }

        // PUT api/scordenabastecimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scordenabastecimiento/5
        public void Delete(int id)
        {
        }
    }
}
