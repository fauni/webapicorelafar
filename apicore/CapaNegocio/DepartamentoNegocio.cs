using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;

namespace CapaNegocio
{
    public class DepartamentoNegocio
    {
        public List<Departamento> GetListaDepartamentos()
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("sp_getDepartamentos");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:" + consulta.Error);

                List<Departamento> ld = new List<Departamento>();
                foreach (DataRow item in dt.Rows)
                {
                    Departamento d = new Departamento
                    {
                        Code = Convert.ToInt32(item["Code"]),
                        Name = item["Name"].ToString(),
                        Remarks = item["Remarks"].ToString(),
                        UserSign = Convert.ToInt32(item["UserSign"]),
                        Father = (item["Father"]).ToString()
                    };
                    ld.Add(d);
                }
                return ld;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return new List<Departamento>();
            }
        }
    }
}
