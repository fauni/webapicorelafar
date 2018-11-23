using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;
using System.Globalization;
using CapaDatos;

namespace CapaNegocio
{
    public class PersonaVacacionNegocio
    {
        public List<PersonaVacacion> GetPersonalZofraVacacion()
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_vacacionesregional");
                consulta.AgregarParametro("@fecha", "20180515");
                consulta.AgregarParametro("@OFI", "administracion zofra");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:" + consulta.Error);

                List<PersonaVacacion> lpv = new List<PersonaVacacion>();
                foreach (DataRow item in dt.Rows)
                {
                    PersonaVacacion u = new PersonaVacacion
                    {
                        empid = Convert.ToInt32(item["empid"]),
                        empleado = item["empleado"].ToString(),
                        fecha_ingreso = Convert.ToDateTime(item["fecha_ingreso"]).ToShortDateString(),
                        fecha = Convert.ToDateTime(item["fecha"]).ToShortDateString(),
                        numdias = Convert.ToSingle(item["numdias"], CultureInfo.CreateSpecificCulture("es-ES")),
                        ant = Convert.ToSingle(item["ant"], CultureInfo.CreateSpecificCulture("es-ES")),
                        saldo = Convert.ToSingle(item["saldo"], CultureInfo.CreateSpecificCulture("es-ES")),
                        duodecima = Convert.ToSingle(item["duodecima"], CultureInfo.CreateSpecificCulture("es-ES")),
                        oficina = item["oficina"].ToString(),
                        area = item["area"].ToString()
                    };
                    lpv.Add(u);
                }
                return lpv;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return new List<PersonaVacacion>();
            }
        }

        public List<PersonaVacacion> GetInfoPersonaVacacion(int id)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_getVacacionPersona");
                consulta.AgregarParametro("@codigoe", id);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:" + consulta.Error);

                List<PersonaVacacion> lpv = new List<PersonaVacacion>();
                foreach (DataRow item in dt.Rows)
                {
                    PersonaVacacion u = new PersonaVacacion
                    {
                        empid = Convert.ToInt32(item["empid"]),
                        empleado = item["empleado"].ToString(),
                        cargo = item["cargo"].ToString(),
                        fecha_ingreso = Convert.ToDateTime(item["fecha_ingreso"]).ToShortDateString(),
                        fecha = (Convert.ToDateTime(item["fecha"])).ToShortDateString(),
                        numdias = Convert.ToSingle(item["numdias"], CultureInfo.CreateSpecificCulture("es-ES")),
                        ant = Convert.ToSingle(item["ant"], CultureInfo.CreateSpecificCulture("es-ES")),
                        saldo = Convert.ToSingle(item["saldo"], CultureInfo.CreateSpecificCulture("es-ES")),
                        duodecima = Convert.ToSingle(item["duodecima"], CultureInfo.CreateSpecificCulture("es-ES")),
                        oficina = item["oficina"].ToString()
                    };
                    lpv.Add(u);
                }
                return lpv;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return new List<PersonaVacacion>();
            }
        }

        // Vacaciones sin sincronizar
        public List<PersonaZofraVacacion> GetVacacionesZofraLafarnet()
        {
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"select u.userid, u.idsap, CONCAT(u.first_name,' ', u.last_name) as Personal, if (total is null, 0, total) as total
                            from lafarnet.users u 
                            left join (select id_usuario_sap ,SUM(dias) as total 
                            from lafarnet.glv_vacaciones 
                            where estado_subida = 0 and estado <> 2
                            group by id_usuario_sap) v on u.idsap= v.id_usuario_sap
                            where u.id_regional = 11 and u.status = 'live';");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:"); // + consulta.Error);

                List<PersonaZofraVacacion> lvzofra = new List<PersonaZofraVacacion>();
                foreach (DataRow item in dt.Rows)
                {
                    PersonaZofraVacacion p = new PersonaZofraVacacion
                    {
                        userid = Convert.ToInt32(item["userid"]),
                        idsap = Convert.ToInt32(item["idsap"]),
                        Personal = (item["Personal"]).ToString(),
                        total = float.Parse(item["total"].ToString(), System.Globalization.CultureInfo.InvariantCulture)
                    };
                    lvzofra.Add(p);
                }
                return lvzofra;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }
        }

        public List<PersonaVacacion> GetEstadoVacaciones()
        {
            try
            {
                CapaDatos.StoreProcedure consultaMS = new CapaDatos.StoreProcedure("sp_vacacionesregional");
                consultaMS.AgregarParametro("@fecha", "20180515");
                consultaMS.AgregarParametro("@OFI", "administracion zofra");
                DataTable dtMS = consultaMS.RealizarConsulta(Parametros.ConexionBDSAP());

                ConsultaMySql consulta = new ConsultaMySql(@"select u.userid, u.idsap, CONCAT(u.first_name,' ', u.last_name) as Personal, if (total is null, 0, total) as total
                            from lafarnet.users u 
                            left join (select id_usuario_sap ,SUM(dias) as total 
                            from lafarnet.glv_vacaciones 
                            where estado_subida = 0 and estado <> 2
                            group by id_usuario_sap) v on u.idsap= v.id_usuario_sap
                            where u.id_regional = 11 and u.status = 'live';");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());

                DataView view = dt.AsDataView();

                List<PersonaVacacion> lvzofra = new List<PersonaVacacion>();
                foreach (DataRow item in dtMS.Rows)
                {
                    view.RowFilter = "idsap=" + item["empid"].ToString();
                    float saldo = 0;
                    if (view.Count > 0)
                    {
                        saldo = float.Parse(view[0][3].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                    }
                    PersonaVacacion p = new PersonaVacacion
                    {
                        empid = Convert.ToInt32(item["empid"]),
                        empleado = item["empleado"].ToString(),
                        cargo = item["cargo"].ToString(),
                        fecha_ingreso = (Convert.ToDateTime(item["fecha_ingreso"])).ToShortDateString(),
                        fecha = (Convert.ToDateTime(item["fecha"])).ToShortDateString(),
                        numdias = float.Parse(item["numdias"].ToString().Replace(',','.'), System.Globalization.CultureInfo.InvariantCulture),
                        ant = float.Parse(item["ant"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture),
                        saldo = float.Parse(item["saldo"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture),
                        saldo_total = float.Parse(item["saldo"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture) - saldo,
                        duodecima = float.Parse(item["duodecima"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture),
                        oficina = item["oficina"].ToString(),
                        area = item["area"].ToString()
                    };
                    lvzofra.Add(p);
                }
                return lvzofra;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }
        }

        #region VACACIONES PERSONAL POR REGIONAL A NIVEL NACIONAL

        public List<PersonaVacacion> GetEstadoVacacionesNacional(string regional)
        {
            try
            {
                CapaDatos.StoreProcedure consultaMS = new CapaDatos.StoreProcedure("sp_vacacionesnacional");
                consultaMS.AgregarParametro("@fecha", "20180515");
                consultaMS.AgregarParametro("@OFI", regional);
                DataTable dtMS = consultaMS.RealizarConsulta(Parametros.ConexionBDSAP());

                ConsultaMySql consulta = new ConsultaMySql(@"select u.userid, u.idsap, CONCAT(u.first_name,' ', u.last_name) as Personal, if (total is null, 0, total) as total
                            from lafarnet.users u 
                            left join (select id_usuario_sap ,SUM(dias) as total 
                            from lafarnet.glv_vacaciones 
                            where estado_subida = 0 and estado <> 2
                            group by id_usuario_sap) v on u.idsap= v.id_usuario_sap
                            where u.status = 'live';");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());

                DataView view = dt.AsDataView();

                List<PersonaVacacion> lvzofra = new List<PersonaVacacion>();
                foreach (DataRow item in dtMS.Rows)
                {
                    view.RowFilter = "idsap=" + item["empid"].ToString();
                    float saldo = 0;
                    if (view.Count > 0)
                    {
                        saldo = float.Parse(view[0][3].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                    }
                    PersonaVacacion p = new PersonaVacacion
                    {
                        empid = Convert.ToInt32(item["empid"]),
                        empleado = item["empleado"].ToString(),
                        cargo = item["cargo"].ToString(),
                        fecha_ingreso = (Convert.ToDateTime(item["fecha_ingreso"])).ToShortDateString(),
                        fecha = (Convert.ToDateTime(item["fecha"])).ToShortDateString(),
                        numdias = float.Parse(item["numdias"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture),
                        ant = float.Parse(item["ant"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture),
                        saldo = float.Parse(item["saldo"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture),
                        saldo_total = float.Parse(item["saldo"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture) - saldo,
                        duodecima = float.Parse(item["duodecima"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture),
                        oficina = item["oficina"].ToString(),
                        area = item["area"].ToString()
                    };
                    lvzofra.Add(p);
                }
                return lvzofra;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }
        }

        #endregion
    }
}
