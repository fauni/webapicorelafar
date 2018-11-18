using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaNegocio;
using CapaModelos;

namespace apicore.Controllers
{
    public class PersonaController : ApiController
    {
        private PersonaVacacionNegocio pn = new PersonaVacacionNegocio();
        ResponsePersona response = new ResponsePersona();
        // GET api/persona
        public ResponsePersonaVacacion Get()
        {
            List<PersonaVacacion> lpv = new List<PersonaVacacion>();
            lpv = pn.GetEstadoVacaciones();
            return new ResponsePersonaVacacion
            {
                status = 200,
                body = lpv,
                length = lpv.Count,
                message = "OK",
            };
        }

        // GET api/persona/5
        public ResponsePersona Get(int id)
        {
            return new ResponsePersona
            {
                status = 200,
                body = null,
                length = 0,
                message = "OK"
            };
        }

        // POST api/persona
        public void Post([FromBody]string value)
        {
        }

        // PUT api/persona/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/persona/5
        public void Delete(int id)
        {
        }
    }
}
