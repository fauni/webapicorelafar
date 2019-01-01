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
    public class SCSolicitudController : ApiController
    {
        SolicitudCompraNegocio sn = new SolicitudCompraNegocio();
        // GET api/scsolicitud
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scsolicitud/5
        public ResponseGetSolicitud Get(string id)
        {
            SolicitudCompra sc = new SolicitudCompra();
            sc = sn.GetSolicitudXCodigo(id);
            return new ResponseGetSolicitud {
                status = 200,
                body = sc,
                message = "OK"
            };
        }

        // POST api/scsolicitud
        public void Post([FromBody]string value)
        {
        }

        // PUT api/scsolicitud/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scsolicitud/5
        public void Delete(int id)
        {
        }
    }
}
