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
    public class SCDetalleOrdenCompraController : ApiController
    {
        SCDetalleOrdenCompraNegocio docn = new SCDetalleOrdenCompraNegocio();
        // GET api/scdetalleordencompra
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scdetalleordencompra/5
        public OCResponseDetalleOrdenCompra Get(string id)
        {
            List<OCDetalleOrdenCompra> ldoc = new List<OCDetalleOrdenCompra>();
            ldoc = docn.GetDetalleOrdenCompra(id);
            return new OCResponseDetalleOrdenCompra
            {
                status=200,
                body = ldoc,
                length = ldoc.Count,
                message = "OK"
            };
        }

        // POST api/scdetalleordencompra
        public ResponseAddDetalleOrdenCompra Post([FromBody]OCDetalleOrdenCompra value)
        {
            if (docn.Add(value)){
                return new ResponseAddDetalleOrdenCompra {
                    status = true,
                    message = "Se guardo correctamente!"
                };       
            } else
            {
                return new ResponseAddDetalleOrdenCompra
                {
                    status = false,
                    message = "No se guardo!"
                };
            }
        }

        // PUT api/scdetalleordencompra/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scdetalleordencompra/5
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
