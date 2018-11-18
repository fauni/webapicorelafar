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
    public class CertificadoAnalisisController : ApiController
    {
        CaracteristicasCertificadoNegocio caracteristicasn = new CaracteristicasCertificadoNegocio();
        // GET api/certificadoanalisis
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    
        // Anular Certificados
        // GET api/certificadoanalisis/5
        public ResponseCertificadoAnalisisMP Get(String id)
        {
            ResponseCertificadoAnalisisMP response = new ResponseCertificadoAnalisisMP();

            if (caracteristicasn.Anular(id.Replace("|", "/")))
            {
                response.status = 200;
                response.body = new CertificadoMPModelo();
                response.length = 1;
                response.message = "Se Anulo el Certificado " + id;
            }
            else
            {
                response.status = 200;
                response.body = new CertificadoMPModelo();
                response.length = 0;
                response.message = "No se pudo Anular el Certificado " + id;
            }
            return response;
        }

        // POST api/certificadoanalisis
        public void Post([FromBody]string value)
        {
        }

        // PUT api/certificadoanalisis/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/certificadoanalisis/5
        public void Delete(int id)
        {
        }
    }
}
