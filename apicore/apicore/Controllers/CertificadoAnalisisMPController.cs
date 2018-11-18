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
    public class CertificadoAnalisisMPController : ApiController
    {
        CertificadoMPModelo certificado = new CertificadoMPModelo();
        CertificadoMPNegocio c = new CertificadoMPNegocio();
        // GET api/certificadoanalisismp
        public ResponseCertificadoAnalisisMP Get()
        {
            ResponseCertificadoAnalisisMP response = new ResponseCertificadoAnalisisMP();
            return response;
        }

        // GET api/certificadoanalisismp/5
        public ResponseCertificadoAnalisisMP Get(string id)
        {
            string codigo_certificado = id.Replace("|", "/");
            ResponseCertificadoAnalisisMP response = new ResponseCertificadoAnalisisMP();
            certificado = c.GetCertificadoMP(codigo_certificado);

            response.status = 200;
            response.message = "Se trajo correctamente el certificado " + codigo_certificado;
            response.body = certificado;
            response.length = 1;

            return response;
        }

        // POST api/certificadoanalisismp
        public void Post([FromBody]string value)
        {
        }

        // PUT api/certificadoanalisismp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/certificadoanalisismp/5
        public void Delete(int id)
        {
        }
    }
}
