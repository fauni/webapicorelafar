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
    public class SCItemArticuloNegocio
    {
        public List<ItemArticuloSC> GetArticulos()
        {
            List<ItemArticuloSC> larticulo = new List<ItemArticuloSC>();
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_items_get]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());

                foreach (DataRow item in dt.Rows)
                {
                    ItemArticuloSC a = new ItemArticuloSC
                    {
                        ItemCode = (item["ItemCode"]).ToString(),
                        ItemName = (item["ItemName"]).ToString(),
                        BuyUnitMsr = (item["BuyUnitMsr"]).ToString()
                    };
                    larticulo.Add(a);
                }
                return larticulo;
            }
            catch (Exception ex)
            {
                return larticulo;
            }
        }
    }
}
