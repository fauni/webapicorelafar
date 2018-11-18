using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using Reportes;
using CapaModelos;
using CapaNegocio;

namespace apicore.Controllers
{
    //[EnableCors("*", "*", "*")]
    // [EnableCors(origins: "https://example.com,http://example.org", headers: "*", methods: "*")] 
    public class CaracteristicasCertificadoController : ApiController
    {
        CaracteristicasCertificadoNegocio caracteristicasn = new CaracteristicasCertificadoNegocio();
        List<CaracteristicaCertificadoModelo> lcaracteristicas = new List<CaracteristicaCertificadoModelo>();
        ResponseCaracteristicas r = new ResponseCaracteristicas();

        // GET api/caracteristicascertificado
        public IEnumerable<string> Get()
        {   
         return new string[] { "value1", "value2" };
        }

        // GET api/caracteristicascertificado/5
        public ResponseCaracteristicas Get(string id)
        {
            string codigo_certificado = id.Replace("|", "/");
            lcaracteristicas = caracteristicasn.GetDatosCaracteristicas(codigo_certificado);
            r.status=200;
            r.body = lcaracteristicas;
            r.length = lcaracteristicas.Count;
            r.message = "Se trajo correctamente las características";
            return r;
        }

        // POST api/caracteristicascertificado
        public ResponseCaracteristica Post([FromBody]CaracteristicaModelo value)
        {
            ResponseCaracteristica response = new ResponseCaracteristica();
            if (caracteristicasn.Add(value))
            {
                response.status = 200;
                response.body = value;
                response.length = 1;
                response.message = "Se guardo correctamente!";
            }
            else
            {
                response.status = 200;
                response.body = value;
                response.length = 0;
                response.message = "No se guardo!";
            }
            return response;
        }

        // PUT api/caracteristicascertificado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/caracteristicascertificado/5
        public ResponseCaracteristica Delete(string id)
        {
            ResponseCaracteristica response = new ResponseCaracteristica();

            if (caracteristicasn.Anular(id.Replace("|","/")))
            {
                response.status = 200;
                response.body = new CaracteristicaModelo();
                response.length = 1;
                response.message = "Se Anulo el Certificado " + id;
            }
            else
            {
                response.status = 200;
                response.body = new CaracteristicaModelo();
                response.length = 0;
                response.message = "No se pudo Anular el Certificado " + id;
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
