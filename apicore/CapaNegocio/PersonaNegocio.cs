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
    public class PersonaNegocio
    {
        public List<Persona> GetPersona()
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:" + consulta.Error);

                List<Persona> lpersona = new List<Persona>();
                foreach (DataRow item in dt.Rows)
                {
                    Persona p = new Persona
                    {
                        empid = Convert.ToInt32(item["empid"]),
                        Nombre = item["Nombre"].ToString(),
                        Area = item["Area"].ToString()
                    };
                    lpersona.Add(p);
                }
                return lpersona;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }

        }

        public List<Persona> GetPersonaM()
        {
            try
            {
                ConsultaMySql consulta = new ConsultaMySql("select * from users");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:"); // + consulta.Error);

                List<Persona> lpersona = new List<Persona>();
                foreach (DataRow item in dt.Rows)
                {
                    Persona p = new Persona
                    {
                        empid = Convert.ToInt32(item["userid"]),
                        Nombre = item["last_name"].ToString(),
                        Area = item["username"].ToString()
                    };
                    lpersona.Add(p);
                }
                return lpersona;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }

        }

        public List<Persona> GetInformacionSAP(int idSap)
        {
            try
            {
                string sql = "select * from lafarnet.users where idsap = " + idSap.ToString();

                ConsultaMySql consulta = new ConsultaMySql(sql);

                List<Persona> lpersona = new List<Persona>();
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                foreach (DataRow item in dt.Rows)
                {
                    Persona p = new Persona
                    {
                        empid = Convert.ToInt32(item["userid"]),
                        Nombre = item["last_name"].ToString(),
                        Area = item["username"].ToString()
                    };
                    lpersona.Add(p);
                }

                return lpersona;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }

        }
    }
}
