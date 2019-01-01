using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaModelos;
using CapaNegocio;

namespace apicore.Controllers.solicitud
{
    public class SCFilesSolicitudAdjuntoController : ApiController
    {
        SCFileNegocio fn = new SCFileNegocio();
        // GET api/scfilessolicitudadjunto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scfilessolicitudadjunto/5
        public ResponseSCFile Get(string id)
        {
            List<SCFile> lfiles = new List<SCFile>();
            lfiles = fn.GetFilesForCodigoSolicitud(id);
            return new ResponseSCFile { 
                status = 200,
                body = lfiles,
                length = lfiles.Count,
                message = "OK"
            };
        }

        // POST api/scfilessolicitudadjunto
        public void Post([FromBody]string value)
        {
        }

        // PUT api/scfilessolicitudadjunto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scfilessolicitudadjunto/5
        public void Delete(int id)
        {
        }
    }
}
