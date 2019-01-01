using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;
using CapaDatos;

namespace CapaNegocio
{
    public class UsuariosNegocio
    {
        public List<Usuarios> GetUsuarioForId(int id)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_getEmpleado");
                consulta.AgregarParametro("@empid", id);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:" + consulta.Error);

                List<Usuarios> lusuario = new List<Usuarios>();
                foreach (DataRow item in dt.Rows)
                {
                    Usuarios u = new Usuarios
                    {
                        empid = Convert.ToInt32(item["empid"]),
                        nombre = item["nombre"].ToString(),
                        area = item["area"].ToString()
                    };
                    lusuario.Add(u);
                }
                return lusuario;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }
        }

        public SCUsuarios GetUsuariosPorUsername(string username)
        {
            SCUsuarios usuario = new SCUsuarios();
            try
            {
                ConsultaMySql consultaMYS = new ConsultaMySql(@"
                        SELECT u.userid, u.first_name, u.last_name, CONCAT(u.first_name,' ', u.last_name) AS 'nombre_completo', u.username, u.email_address AS 'email', r.nombre AS 'regional', a.nombre AS 'area'
                        from newlafarnet.users u
                        INNER JOIN areas a ON a.id = u.id_area
                        INNER JOIN regional r ON r.id = u.id_regional
                        WHERE u.username = '"+ username + @"';");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consultaMYS.EjecutarConsulta(Parametros.ConexionBDMySQL());
                
                foreach (DataRow item in dt.Rows)
                {
                    SCUsuarios u = new SCUsuarios
                    {
                        userid = Convert.ToInt32(item["userid"]),
                        first_name = (item["first_name"]).ToString(),
                        last_name = (item["last_name"]).ToString(),
                        nombre_completo = (item["nombre_completo"]).ToString(),
                        username = (item["username"]).ToString(),
                        email = (item["email"]).ToString(),
                        regional = (item["regional"]).ToString(),
                        area = (item["area"]).ToString()
                    };
                    usuario = u;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return usuario;
            }
        }
    }
}
