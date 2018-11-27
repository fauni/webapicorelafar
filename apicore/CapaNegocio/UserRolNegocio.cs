using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using System.Data;

namespace CapaNegocio
{
    public class UserRolNegocio
    {
        // Vacaciones sin sincronizar
        public UserRol GetUserRolApp(RequestUserApp ura)
        {
            UserRol ou = new UserRol();
            List<UserRol> lura = new List<UserRol>();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"
                    select ur.id, ur.username, ur.id_rol from user_rol ur
                    inner join roles r on r.id_rol = ur.id_rol
                    inner join apps a on a.code = r.codigo_app
                    where a.id = "+ura.id_app+@" and username = '"+ura.username+@"';
                ");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:"); // + consulta.Error);

                foreach (DataRow item in dt.Rows)
                {
                    UserRol ur = new UserRol
                    {
                        id = Convert.ToInt32(item["id"]),
                        username = (item["username"]).ToString(),
                        id_rol = Convert.ToInt32(item["id_rol"])
                    };
                    lura.Add(ur);
                    ou = ur;
                }
                return ou;
            }
            catch (Exception ex)
            {
                return ou;
            }
        }
    }
}
