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
    public class UsuariosController : ApiController
    {
        private UsuariosNegocio usuario = new UsuariosNegocio();
        ResponseUsuarios response = new ResponseUsuarios();
        // GET api/usuarios
        public ResponseUsuarios Get()
        {
            return new ResponseUsuarios
            {
                status = 200,
                body = usuario.GetUsuarioForId(1),
                length = usuario.GetUsuarioForId(1).Count(),
                message = "OK"
            };
        }

        // GET api/usuarios/5
        public ResponseUsuarios Get(int id)
        {
            return new ResponseUsuarios
            {
                status = 200,
                body = usuario.GetUsuarioForId(id),
                length = usuario.GetUsuarioForId(id).Count,
                message = "OK"
            };
        }

        // POST api/usuarios
        public string Post([FromBody]Usuarios value)
        {
            return "";//return usuario.insertaUsuario(value);
        }

        // PUT api/usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/usuarios/5
        public void Delete(int id)
        {
        }
    }
}
