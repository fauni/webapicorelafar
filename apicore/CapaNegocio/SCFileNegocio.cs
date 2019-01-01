using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using System.Data;

namespace CapaNegocio
{
    public class SCFileNegocio
    {
        public List<SCFile> GetFilesForCodigoSolicitud(string codigo_solicitud)
        {
            List<SCFile> lsc = new List<SCFile>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_files_solicitud]");
                consulta.AgregarParametro("@codigo_solicitud", codigo_solicitud);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    SCFile scfile = new SCFile
                    {
                        id = Convert.ToInt32(item["id"]),
                        Tipo = (item["Tipo"]).ToString(),
                        Nombre = (item["Nombre"]).ToString(),
                        Extension = (item["Extension"]).ToString(),
                        NombreGenerico = (item["NombreGenerico"]).ToString(),
                        codigo_solicitud = (item["codigo_solicitud"]).ToString(),
                        tamanio = Convert.ToInt64(item["tamanio"])
                        
                    };
                    lsc.Add(scfile);
                }
                return lsc;
            }
            catch (Exception ex)
            {
                return lsc;
            }
        }

        public Boolean Add(SCFile f)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_file_insert]");
                consulta.AgregarParametro("@Tipo", f.Tipo);
                consulta.AgregarParametro("@Nombre", f.Nombre);
                consulta.AgregarParametro("@Extension", f.Extension);
                consulta.AgregarParametro("@NombreGenerico", f.NombreGenerico);
                consulta.AgregarParametro("@codigo_solicitud", f.codigo_solicitud);
                consulta.AgregarParametro("@length", f.tamanio);

                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
