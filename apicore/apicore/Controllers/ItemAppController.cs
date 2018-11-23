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
    public class ItemAppController : ApiController
    {
        ItemAppNegocio ian = new ItemAppNegocio();
        ResponseItemApp response = new ResponseItemApp();

        // GET api/itemapp
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/itemapp/5
        public ResponseItemApp Get(int id)
        {
            List<ItemApp> lia = new List<ItemApp>();
            lia = ian.GetListaItems(id);
            response.status = 200;
            response.body = lia;
            response.length = lia.Count;
            response.message = "OK";
            return response;
        }

        // POST api/itemapp
        public void Post([FromBody]string value)
        {
        }

        // PUT api/itemapp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/itemapp/5
        public void Delete(int id)
        {
        }
    }
}
