using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CapaModelos;
using System.IO;
using System.Net.Http.Headers;
using System.Globalization;
using CapaNegocio;
using Comunes;

namespace apicore.Controllers
{
    public class SCFilesSolicitudCompraController : ApiController
    {
        SCFileNegocio sfn = new SCFileNegocio();
        // GET api/scfilessolicitudcompra
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/scfilessolicitudcompra/5
        public HttpResponseMessage Get(string id)
        {
            string[] archivo = id.Split('|');
            string name_file = WS_SegNet.EncriptarValor(archivo[0]) +"."+ archivo[1];

            if (!string.IsNullOrEmpty(name_file)) {
                string filePath = "/sc/solicitud/";
                string fullPath = AppDomain.CurrentDomain.BaseDirectory + filePath + "/" + name_file;
                if (File.Exists(fullPath))
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var filestream = new FileStream(fullPath, FileMode.Open);
                    response.Content = new StreamContent(filestream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = id.Replace("|",".");
                    return response;
                }
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // POST api/scfilessolicitudcompra
        public ResponseSCFile Post()
        {
            DateTime dt = DateTime.Now;
            string cod = ""; // dt.ToString("yyMMddss");

            int iUploadedCnt = 0;
            List<SCFile> lfiles = new List<SCFile>();
            // DEFINE EL LUGAR DONDE SERA GUARDADO EL O LOS ARCHIVOS ADJUNTOS.
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/sc/solicitud/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                SCFile f = new SCFile();
                System.Web.HttpPostedFile hpf = hfc[iCnt];
                if (hpf.ContentLength > 0)
                {
                    string nombre = hpf.FileName;
                    string[] archivo = nombre.Split('.');
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    //if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    if (!File.Exists(sPath + Path.GetFileName(Comunes.WS_SegNet.EncriptarValor(archivo[0]+cod)+"."+archivo[1])))
                    {
                        // Guardamos los archivos en la carpeta.
                        hpf.SaveAs(sPath + Path.GetFileName(Comunes.WS_SegNet.EncriptarValor(archivo[0]+cod) + "." +archivo[1]));
                        iUploadedCnt = iUploadedCnt + 1;

                        //Cargamos 
                        f.Tipo = hpf.ContentType;
                        f.tamanio = hpf.ContentLength;
                        f.Nombre = hpf.FileName;
                        f.NombreGenerico = Comunes.WS_SegNet.EncriptarValor(archivo[0]+ cod);
                        f.Extension = archivo[1];
                        lfiles.Add(f);
                    }
                }
            }
            
            // RETURN A MESSAGE.
            //if (iUploadedCnt > 0)
            return new ResponseSCFile
            {
                status = 200,
                body = lfiles,
                length = lfiles.Count,
                message = "Se subieron " + iUploadedCnt + " archivos: " + Comunes.WS_SegNet.EncriptarValor("lafarnetadm")
            };
        }

        // PUT api/scfilessolicitudcompra/5
        public ResponseSaveSCFile Put(string id, [FromBody] List<SCFile> value)
        {
            int count = 0;
            foreach (var item in value)
            {
                SCFile f = new SCFile
                {
                    id = (item.id),
                    Tipo = (item.Tipo),
                    Nombre = (item.Nombre),
                    Extension = (item.Extension),
                    NombreGenerico = (item.NombreGenerico),
                    codigo_solicitud = id,
                    tamanio = (item.tamanio)
                };
                if (this.sfn.Add(f))
                {
                    count++;
                }
            }
            ResponseSaveSCFile response = new ResponseSaveSCFile();
            if (count > 0)
            {
                response.ok = true;
            }
            else
            {
                response.ok = false;
            }
            response.status = 200;
            response.message = "OK";
            return response;
        }

        // DELETE api/scfilessolicitudcompra/5
        public void Delete(int id)
        {
        }

        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
