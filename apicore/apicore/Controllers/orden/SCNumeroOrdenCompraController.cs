using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaNegocio;
using CapaModelos;

namespace apicore.Controllers.orden
{
    public class SCNumeroOrdenCompraController : ApiController
    {
        SCExportarOrdenCompraNegocio o = new SCExportarOrdenCompraNegocio();
        // GET api/scnumeroordencompra
        public ResponseVerificaTransferenciaOC Get()
        {
            return new ResponseVerificaTransferenciaOC
            {
                status = 200,
                result = o.verificaSiExistenOrdenParaSubir()
            };
        }

        // GET api/scnumeroordencompra/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/scnumeroordencompra
        public void Post([FromBody]string value)
        {
        }

        // PUT api/scnumeroordencompra/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scnumeroordencompra/5
        public void Delete(int id)
        {
        }
    }
}
