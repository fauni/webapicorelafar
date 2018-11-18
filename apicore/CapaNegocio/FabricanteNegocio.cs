using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;

namespace CapaNegocio
{
    public class FabricanteNegocio
    {
        public List<Fabricante> GetListaFabricantes()
        {
            List<Fabricante> lfabricante = new List<Fabricante>();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"select * from newlafarnet.sacc_fabricante;");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos  de la consulta de la base de datos");

                foreach (DataRow item in dt.Rows)
                {
                    Fabricante f = new Fabricante
                    {
                        id_fabricante = Convert.ToInt32(item["id_fabricante"]),
                        nombre_fabricante = (item["nombre_fabricante"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    lfabricante.Add(f);
                }
                return lfabricante;
            }
            catch (Exception ex)
            {
                return lfabricante;
            }
        }

        public Boolean Add(Fabricante f)
        {
            try
            {
                String sql = @"insert into newlafarnet.sacc_fabricante (nombre_fabricante, usuario_creacion, fecha_creacion, usuario_modificacion, fecha_modificacion) 
                    values ('"+f.nombre_fabricante+@"', '"+f.usuario_creacion+@"', now(), '"+f.fecha_modificacion+@"', now());";
                ConsultaMySql consulta = new ConsultaMySql(sql);
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
