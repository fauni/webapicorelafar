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
    public class PersonaVacacionController : ApiController
    {
        private PersonaVacacionNegocio pv = new PersonaVacacionNegocio();
        ResponsePersonaVacacion response = new ResponsePersonaVacacion();
        
        // GET api/personavacacion
        public ResponsePersonaVacacion Get()
        {
            List<PersonaVacacion> lzofra = new List<PersonaVacacion>();
            lzofra = pv.GetPersonalZofraVacacion();

            List<PersonaZofraVacacion> lpv = new List<PersonaZofraVacacion>();
            lpv = pv.GetVacacionesZofraLafarnet();

            

            return new ResponsePersonaVacacion
            {
                status = 200,
                body = lzofra,
                length = lzofra.Count,
                message = "OK"
            };
        }

        // GET api/personavacacion/5
        public ResponsePersonaVacacion Get(int id)
        {
            List<PersonaVacacion> lpv = new List<PersonaVacacion>();
            lpv = pv.GetInfoPersonaVacacion(id);
            return new ResponsePersonaVacacion
            {
                status = 200,
                body = lpv,
                length = lpv.Count,
                message = "OK"
            };
        }

        // POST api/personavacacion
        public void Post([FromBody]string value)
        {
        }

        // PUT api/personavacacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/personavacacion/5
        public void Delete(int id)
        {
        }
    }
}
