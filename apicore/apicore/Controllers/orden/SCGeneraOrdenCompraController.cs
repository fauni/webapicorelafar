using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Reportes;

namespace apicore.Controllers.orden
{
    public class SCGeneraOrdenCompraController : ApiController
    {
        OrdenCompra rorden = new OrdenCompra();
        // GET api/scgeneraordencompra
        public string Get()
        {
            rorden.crearReporteOrdenCompra("temporal");
            return "true";
        }

        // GET api/scgeneraordencompra/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/scgeneraordencompra
        public void Post([FromBody]string value)
        {

        }

        // PUT api/scgeneraordencompra/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scgeneraordencompra/5
        public void Delete(int id)
        {
        }
    }
}
