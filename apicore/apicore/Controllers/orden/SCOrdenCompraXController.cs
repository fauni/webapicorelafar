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
    public class SCOrdenCompraXController : ApiController
    {
        SCOrdenCompraNegocio ocn = new SCOrdenCompraNegocio();

        // GET api/scordencomprax
        public ResponseListadoOrdenCompraAbastecimiento Get()
        {
            List<OrdenCompraListAbastecimiento> loc = new List<OrdenCompraListAbastecimiento>();
            loc = ocn.GetOrdenesCompras();
            return new ResponseListadoOrdenCompraAbastecimiento
            {
                status = 200,
                body = loc,
                length = loc.Count,
                message = "OK"
            };
        }

        // GET api/scordencomprax/5
        public ResponseOrdenCompra Get(string id)
        {
            OCOrdenCompra oc = new OCOrdenCompra();
            oc = ocn.GetOrdenCompra(id);
            return new ResponseOrdenCompra
            {
                status = 200,
                body = oc,
                message = "OK"
            };
        }

        // POST api/scordencomprax
        public ResponseAddOrdenCompra Post([FromBody]OCOrdenCompra value)
        {
            ResponseAddOrdenCompra response = new ResponseAddOrdenCompra();
            if (ocn.Add(value))
            {
                response.status = 200;
                response.message = "Se guardo correctamente!";
            }
            else
            {
                response.status = 304;
                response.message = "No se guardo!";
            }
            return response;
        }

        // PUT api/scordencomprax/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scordencomprax/5
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
