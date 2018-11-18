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
    public class FabricanteController : ApiController
    {
        FabricanteNegocio fn = new FabricanteNegocio();
        // GET api/fabricante
        public ResponseFabricante Get()
        {
            List<Fabricante> lf = new List<Fabricante>();
            lf = fn.GetListaFabricantes();
            ResponseFabricante response = new ResponseFabricante();
            response.status = 200;
            response.body = lf;
            response.length= lf.Count;
            response.message = "OK";
            return response;
        }

        // GET api/fabricante/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/fabricante
        public ResponseFabricante Post([FromBody]Fabricante value)
        {
            ResponseFabricante response = new ResponseFabricante();
            if (fn.Add(value))
            {
                response.status = 200;
                response.body = new List<Fabricante>();
                response.length = 1;
                response.message = "Se guardo correctamente!";
            }
            else
            {
                response.status = 200;
                response.body = new List<Fabricante>();
                response.length = 0;
                response.message = "No se guardo!";
            }
            return response;
        }

        // PUT api/fabricante/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/fabricante/5
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
