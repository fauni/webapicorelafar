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
    public class SolicitudCompraController : ApiController
    {
        SolicitudCompraNegocio sn = new SolicitudCompraNegocio();
        // GET api/solicitudcompra
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/solicitudcompra/5
        public ResponseGetSolicitudesXUsuario Get(string id)
        {
            List<Solicitudcompralistado> lsolicitud = new List<Solicitudcompralistado>();
            lsolicitud = sn.GetSolicitudesXUsuario(id);
            return new ResponseGetSolicitudesXUsuario { 
                status = 200,
                body = lsolicitud,
                length = lsolicitud.Count,
                message = "OK" 
            };
        }

        // POST api/solicitudcompra
        public ResponseAddSolicitud Post([FromBody]SolicitudCompra value)
        {
            ResponseAddSolicitud response = new ResponseAddSolicitud();
            if (sn.Add(value))
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

        // PUT api/solicitudcompra/5
        public ResponseAddSolicitud Put(int id, [FromBody]SolicitudCompra value)
        {
            ResponseAddSolicitud response = new ResponseAddSolicitud();
            if (sn.Edit(value))
            {
                response.status = 200;
                response.message = "Se modifico correctamente!";
            }
            else
            {
                response.status = 304;
                response.message = "No se modifico!";
            }
            return response;
        }

        // DELETE api/solicitudcompra/5
        public ResponseAddSolicitud Delete(string id)
        {
            ResponseAddSolicitud response = new ResponseAddSolicitud();
            if (sn.Delete(id))
            {
                response.status = 200;
                response.message = "Se elimino correctamente!";
            }
            else
            {
                response.status = 304;
                response.message = "No se elimino!";
            }
            return response;
        }
            
        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
