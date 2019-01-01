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
    public class SCTipoCompraEncargadoController : ApiController
    {
        SCTipoCompraEncargadoNegocio tcen = new SCTipoCompraEncargadoNegocio();
        // GET api/sctipocompraencargado
        public ResponseTipoCompraEncargado Get()
        {
            List<OCTipoCompraEncargado> ltce = new List<OCTipoCompraEncargado>();
            ltce = tcen.GetTipoCompraEncargado();
            return new ResponseTipoCompraEncargado
            {
                status = 200,
                body = ltce,
                length = ltce.Count,
                message = "OK"
            };
        }

        // GET api/sctipocompraencargado/5
        public ResponseTipoCompraEncargadoSingle Get(string id)
        {
            OCTipoCompraEncargado tce = new OCTipoCompraEncargado();
            tce = tcen.GetTipoCompraEncargadoSingle(id);
            return new ResponseTipoCompraEncargadoSingle
            {
                status = 200,
                body = tce,
                message = "OK"
            };
        }

        // POST api/sctipocompraencargado
        public void Post([FromBody]string value)
        {
        }

        // PUT api/sctipocompraencargado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/sctipocompraencargado/5
        public void Delete(int id)
        {
        }
    }
}
