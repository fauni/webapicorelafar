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
    public class CertificadoMPController : ApiController
    {
        CertificadoMPNegocio certificadompn = new CertificadoMPNegocio();
        CaracteristicasCertificadoNegocio ccnegocio = new CaracteristicasCertificadoNegocio();
        CertificadoMP rep = new CertificadoMP();

        // GET api/certificadomp
        public string Get()
        {
            // rep.Crear();
            return "true";
        }

        // GET api/certificadomp/5
        public HttpResponseMessage Get(string id)
        {
            string codigo_certificado = id.Replace("|", "/"); // Obtenemos el codigo del certificado | a /

            List<CertificadoMPModelo> listacomp = new List<CertificadoMPModelo>();
            List<CaracteristicaCertificadoModelo> lcaracteristicas = new List<CaracteristicaCertificadoModelo>();
            lcaracteristicas = ccnegocio.GetDatosCaracteristicas(codigo_certificado); 

            CertificadoMP rep = new CertificadoMP();

            //Creamos Listas por tipo de característica
            List<CaracteristicaCertificadoModelo> lcf = new List<CaracteristicaCertificadoModelo>();
            //List<CaracteristicaCertificadoModelo> laq = new List<CaracteristicaCertificadoModelo>();
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
                else if (caracteristica.tipo_caracteristica == "CM")
                {
                    lcm.Add(caracteristica);
                }
                
            }



            
            //Esto sirve para listar varios certificados
            List<CertificadoMPModelo> listacmp = new List<CertificadoMPModelo>(); // Creamos la Lista de Certificados             
            listacmp = this.certificadompn.GetDatosCertificadoMP(codigo_certificado);


            CertificadoMPModelo certificado = new CertificadoMPModelo();
            certificado = certificadompn.GetCertificadoMPReport(codigo_certificado);

            rep.Crear(certificado, lcf, lcm);

            //rep.Crear(certificado);

            HttpResponseMessage response = new HttpResponseMessage();
            var localFilePath = Parametros.rutaCertificadoMP() + codigo_certificado + ".pdf"; //HttpContext.Current.Server.MapPath("~/certificadosmp/prueba.pdf");
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

        // POST api/certificadomp
        public void Post([FromBody]string value)
        {
        }

        // PUT api/certificadomp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/certificadomp/5
        public void Delete(int id)
        {
        }
    }
}
