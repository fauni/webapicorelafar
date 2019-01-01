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
    public class SCDetalleSolicitudController : ApiController
    {
        SCDetalleSolicitudCompraNegocio dsc = new SCDetalleSolicitudCompraNegocio();
        // GET api/scdetallesolicitud
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scdetallesolicitud/5
        public ResponseGetDetallesSolicitud Get(string id)
        {
            List<DetalleSolicitudCompraSC> ldetallesolicitud = new List<DetalleSolicitudCompraSC>();
            ldetallesolicitud = dsc.GetDetalleSolicitudXCodigo(id);
            return new ResponseGetDetallesSolicitud { 
                status = 200,
                body = ldetallesolicitud,
                length = ldetallesolicitud.Count,
                message = "OK"
            };
        }

        // POST api/scdetallesolicitud
        public ResponseAddDetalleSolicitud Post([FromBody]DetalleSolicitudCompraSC value)
        {
            ResponseAddDetalleSolicitud response = new ResponseAddDetalleSolicitud();
            if (dsc.Add(value))
            {
                response.status = 200;
                response.message = "Se guardo correctamente!";
            }
            else
            {
                response.status = 200;
                response.message = "No se guardo!";
            }
            return response;
        }

        // PUT api/scdetallesolicitud/5
        public ResponseUpdateEstadoDetalleSolicitudCompra Put(int id, [FromBody]RequestUpdateEstadoDetalleSolicitudCompra value)
        {
            ResponseUpdateEstadoDetalleSolicitudCompra response = new ResponseUpdateEstadoDetalleSolicitudCompra();
            if (dsc.UpdateEstado(value))
            {
                response.result = true;
                response.status = 200;
                response.message = "Se modifico correctamente!";
            }
            else
            {
                response.result = false;
                response.status = 200;
                response.message = "No se modifico!";
            }
            return response;
        }

        // DELETE api/scdetallesolicitud/5
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
