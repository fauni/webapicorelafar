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
    public class SCProveedorNegocio
    {
        public List<ProveedorSC> GetProveedores()
        {
            List<ProveedorSC> lproveedor = new List<ProveedorSC>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_sc_get_proveedores]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    ProveedorSC p = new ProveedorSC
                    {
                        CardCode = (item["CardCode"]).ToString(),
                        CardName = (item["CardName"]).ToString(),
                        MailAddres = (item["MailAddres"]).ToString(),
                        CntctPrsn = (item["CntctPrsn"]).ToString(),
                        Cellular = (item["Cellular"]).ToString()
                    };
                    lproveedor.Add(p);
                }
                return lproveedor;
            }
            catch (Exception ex)
            {
                return lproveedor;
            }
        }
    }
}
