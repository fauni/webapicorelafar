using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class RolNegocio
    {
        public List<Rol> GetListaRol(string codigo_aplicacion)
        {
            List<Rol> lrol = new List<Rol>();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"SELECT * FROM newlafarnet.roles WHERE codigo_app = '"+codigo_aplicacion+@"';");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos  de la consulta de la base de datos");

                foreach (DataRow item in dt.Rows)
                {
                    Rol r = new Rol
                    {
                        id_rol = Convert.ToInt32(item["id_rol"]),
                        nombre_rol = (item["nombre_rol"]).ToString(),
                        codigo_app = (item["codigo_app"]).ToString(),
                        descripcion = (item["descripcion"]).ToString()
                    };
                    lrol.Add(r);
                }
                return lrol;
            }
            catch (Exception ex)
            {
                return lrol;
            }
        }
    }
}
