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
    public class SCProveedorController : ApiController
    {
        SCProveedorNegocio pn = new SCProveedorNegocio();
        // GET api/scproveedor
        public ResponseProveedoresSC Get()
        {
            List<ProveedorSC> lp = new List<ProveedorSC>();
            lp = pn.GetProveedores();
            return new ResponseProveedoresSC { 
                status=200,
                body = lp,
                length = lp.Count,
                message = "OK"
            };
        }

        // GET api/scproveedor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/scproveedor
        public void Post([FromBody]string value)
        {
        }

        // PUT api/scproveedor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/scproveedor/5
        public void Delete(int id)
        {
        }
    }
}
