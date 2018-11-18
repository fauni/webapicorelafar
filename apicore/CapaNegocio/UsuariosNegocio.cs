using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;

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
    }
}
