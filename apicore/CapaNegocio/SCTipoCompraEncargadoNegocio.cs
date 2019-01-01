using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;

namespace CapaNegocio
{
    public class SCTipoCompraEncargadoNegocio
    {
        public List<OCTipoCompraEncargado> GetTipoCompraEncargado()
        {
            List<OCTipoCompraEncargado> ltce = new List<OCTipoCompraEncargado>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_tipo_compra_encargado_get]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    OCTipoCompraEncargado a = new OCTipoCompraEncargado
                    {
                        id_tipo = Convert.ToInt32(item["id_tipo"]),
                        codigo_tipo_compra = (item["codigo_tipo_compra"]).ToString(),
                        descripcion = (item["descripcion"]).ToString(),
                        username = (item["username"]).ToString(),
                        nombre_encargado = (item["nombre_encargado"]).ToString()
                    };
                    ltce.Add(a);
                }
                return ltce;
            }
            catch (Exception ex)
            {
                return ltce;
            }
        }

        public OCTipoCompraEncargado GetTipoCompraEncargadoSingle(string tipo_compra)
        {
            OCTipoCompraEncargado tce = new OCTipoCompraEncargado();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_tipo_compra_encargado_single_get]");
                consulta.AgregarParametro("@tipo_compra", tipo_compra);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    OCTipoCompraEncargado a = new OCTipoCompraEncargado
                    {
                        id_tipo = Convert.ToInt32(item["id_tipo"]),
                        codigo_tipo_compra = (item["codigo_tipo_compra"]).ToString(),
                        descripcion = (item["descripcion"]).ToString(),
                        username = (item["username"]).ToString(),
                        nombre_encargado = (item["nombre_encargado"]).ToString()
                    };
                    tce = a;
                }
                return tce;
            }
            catch (Exception ex)
            {
                return tce;
            }
        }
    }
}
