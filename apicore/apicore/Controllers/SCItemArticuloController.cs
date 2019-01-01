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
    public class SCItemArticuloController : ApiController
    {
        SCItemArticuloNegocio ian = new SCItemArticuloNegocio();
        // GET api/scitemarticulo
        public ResponseItemArticuloSC Get()
        {
            List<ItemArticuloSC> lia = new List<ItemArticuloSC>();
            lia = ian.GetArticulos();
            return new ResponseItemArticuloSC
            {
                status = 200,
                body = lia,
                length = lia.Count,
                message = "OK"
            };
        }

        // GET api/scitemarticulo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/scitemarticulo
        public void Post([FromBody]string value)
        {
        }

        // PUT api/scitemarticulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scitemarticulo/5
        public void Delete(int id)
        {
        }
    }
}
