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
        public ResponsePersonaVacacion Get(string id)
        {
            List<PersonaVacacion> lpv = new List<PersonaVacacion>();
            lpv = pn.GetEstadoVacacionesNacional(id.Replace("|", "."));
            return new ResponsePersonaVacacion
            {
                status = 200,
                body = lpv,
                length = lpv.Count,
                message = "OK",
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
