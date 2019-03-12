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
    public class NotificacionOrdenController : ApiController
    {
        NotificacionOrdenNegocio no = new NotificacionOrdenNegocio();
        // GET api/notificacionorden
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/notificacionorden/5
        public ResponseNotificacionCreateOrden Get(string id)
        {
            List<NotificacionOrden> ln = new List<NotificacionOrden>();
            ln = no.GetSolicitantesOrden(id);
            return new ResponseNotificacionCreateOrden
            {
                status = 200,
                body = ln,
                length = ln.Count,
                message = "OK"
            };
        }

        // POST api/notificacionorden
        public void Post([FromBody]string value)
        {
        }

        // PUT api/notificacionorden/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/notificacionorden/5
        public void Delete(int id)
        {
        }
    }
}
