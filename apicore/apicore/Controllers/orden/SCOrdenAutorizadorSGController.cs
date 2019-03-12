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
    public class SCOrdenAutorizadorSGController : ApiController
    {
        SCOrdenCompraNegocio on = new SCOrdenCompraNegocio();
        // GET api/scordenautorizadorsg
        public ResponseListadoOrdenCompraAbastecimiento Get()
        {
            string id = "T";
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

        // GET api/scordenautorizadorsg/5
        public ResponseListadoOrdenCompraAbastecimiento Get(string id)
        {
            List<OrdenCompraListAbastecimiento> lorden = new List<OrdenCompraListAbastecimiento>();
            lorden = on.GetListadoOrdenPorAutorizador(id);
            return new ResponseListadoOrdenCompraAbastecimiento
            {
                status = 200,
                body = lorden,
                length = lorden.Count,
                message = "OK"
            };
        }

        // POST api/scordenautorizadorsg
        public ResponseAddOrdenCompra Post([FromBody]RequestAutorizacionSolicitud value)
        {
            if (on.Autorizar(value))
            {
                return new ResponseAddOrdenCompra()
                {
                    status = 200,
                    message = "TRUE"
                };
            }
            else
            {
                return new ResponseAddOrdenCompra()
                {
                    status = 304,
                    message = "FALSE"
                };
            }
        }

        // PUT api/scordenautorizadorsg/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scordenautorizadorsg/5
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
