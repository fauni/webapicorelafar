using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;

namespace CapaNegocio
{
    public class SCExportarOrdenCompraNegocio
    {
        // Obtengo el ultimo Numero de Orden
        public Int64 getNumeroOrden()
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_get_numero_orden_compra]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                Int64 numero_orden = Convert.ToInt64(dt.Rows[0][0]);
                return numero_orden;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public void updateEstadoSubidaOrden(RequestUpdateEstadoSubidaOrden s)
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_update_estado_transferencia_orden]");
                consulta.AgregarParametro("@numero_orden_compra", s.numero_orden_compra);
                consulta.AgregarParametro("@estado_transferencia", s.estado_transferencia);
                consulta.AgregarParametro("@codigo_orden", s.codigo_orden);
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
            }
            catch (Exception ex)
            {
                
            }
        }

        // Función que sirve para verificar si existen ordenes sin sincronizar con el SAP
        public Boolean verificaSiExistenOrdenParaSubir()
        {
            try
            {
                CapaDatos.StoreProcedure consulta = new CapaDatos.StoreProcedure("[lafarnet].[dbo].[sp_verifica_estado_de_transferencia]");
                DataTable dt = consulta.RealizarConsulta(Parametros.ConexionBDSAP());
                if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
