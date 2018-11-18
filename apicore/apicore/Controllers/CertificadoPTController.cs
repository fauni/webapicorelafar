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
    public class CertificadoPTController : ApiController
    {
        CertificadoPTNegocio certificadoptn = new CertificadoPTNegocio();
        CaracteristicasCertificadoNegocio ccnegocio = new CaracteristicasCertificadoNegocio();
        CertificadoPT rep = new CertificadoPT();

        // GET api/certificadopt
        public string Get()
        {
           //CertificadoPT rep = new CertificadoPT();
            //rep.Crear();
            return "true";
        }

        // GET api/certificadopt/5
        public HttpResponseMessage Get(string id)

        {
            string codigo_certificado = id.Replace("|", "/"); // Obtenemos el codigo del certificado | a /

            List<CertificadoPTModelo> listacopt = new List <CertificadoPTModelo>();
            //Creamos caracteristicas certificado
            List<CaracteristicaCertificadoModelo> lcaracteristicas = new List<CaracteristicaCertificadoModelo>();
            lcaracteristicas = ccnegocio.GetDatosCaracteristicas(codigo_certificado);

            //Creamos Listas por tipo de característica
            List<CaracteristicaCertificadoModelo> lcf = new List<CaracteristicaCertificadoModelo>();
            List<CaracteristicaCertificadoModelo> laq = new List<CaracteristicaCertificadoModelo>();
            List<CaracteristicaCertificadoModelo> lcm = new List<CaracteristicaCertificadoModelo>();
            foreach (var item in lcaracteristicas)
            {
                // Console.WriteLine(item);
                CaracteristicaCertificadoModelo caracteristica = new CaracteristicaCertificadoModelo();
                caracteristica.codigo_producto = item.codigo_producto;
                caracteristica.id_caracteristica = item.id_caracteristica;
                caracteristica.especificacion = item.especificacion;
                caracteristica.resultado = item.resultado;
                caracteristica.tipo_caracteristica = item.tipo_caracteristica;
                caracteristica.estado = item.estado;
                caracteristica.usuario_creacion = item.usuario_creacion;
                caracteristica.fecha_creacion = item.fecha_creacion;
                caracteristica.usuario_modificacion = item.usuario_modificacion;
                caracteristica.fecha_modificacion = item.fecha_modificacion;

                if (caracteristica.tipo_caracteristica == "CF")
                {
                    lcf.Add(caracteristica);
                }
                else if (caracteristica.tipo_caracteristica == "AQ")
                {
                    laq.Add(caracteristica);
                }
                else
                {
                    lcm.Add(caracteristica);
                }
                
            }
            
            //Esto sirve para listar varios certificados
            //List<CertificadoMPModelo> listacmp = new List<CertificadoMPModelo>(); // Creamos la Lista de Certificados             
            //listacmp = this.certificadompn.GetDatosCertificadoMP(codigo_certificado);
            List <CertificadoPTModelo >listacpt = new List<CertificadoPTModelo >();
            listacpt = this.certificadoptn.GetDatosCertificadoPT (codigo_certificado);

            CertificadoPTModelo certificado = new CertificadoPTModelo();
            certificado = certificadoptn.GetCertificadoPTReport(codigo_certificado);
            rep.Crear(certificado, lcf, laq, lcm);


            HttpResponseMessage response = new HttpResponseMessage();
            var localFilePath = Parametros.rutaCertificadoPT() + codigo_certificado.Replace("/","#") + ".pdf";
            byte[] pdfbytes = System.IO.File.ReadAllBytes(localFilePath);
            if (!File.Exists(localFilePath))
            {
                response = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new ByteArrayContent(pdfbytes);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            }
            return response;
        }

        // POST api/certificadopt
        public void Post([FromBody]string value)
        {
        }

        // PUT api/certificadopt/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/certificadopt/5
        public void Delete(int id)
        {
        }
    }
}
