using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CapaNegocio
{
    public class Parametros
    {
        public static string rutaOrdenCompra()
        {
            try
            {
                return ConfigurationManager.AppSettings["RUTA_ORDEN"].ToString();
            }
            catch
            {
                return "C:\\INTRANET\\SC\\ORDEN";//Se devuelve un valor estatico ya que al ser variable de inicializacion no se debe levantar error
            }
        }

        public static string rutaDetalleOrdenCompra()
        {
            try
            {
                return ConfigurationManager.AppSettings["RUTA_DETALLE_ORDEN"].ToString();
            }
            catch
            {
                return "C:\\INTRANET\\SC\\DETALLE_ORDEN";//Se devuelve un valor estatico ya que al ser variable de inicializacion no se debe levantar error
            }
        }

        public static string rutaCertificadoMP()
        {
            try
            {
                return ConfigurationManager.AppSettings["RUTA_CERTIFICADOS_MP"].ToString();
            }
            catch
            {
                return "C:\\INTRANET\\SACC\\CertificadosMP";//Se devuelve un valor estatico ya que al ser variable de inicializacion no se debe levantar error
            }
        }

        public static string rutaCertificadoPT()
        {
            try
            {
                return ConfigurationManager.AppSettings["RUTA_CERTIFICADOS_PT"].ToString();
            }
            catch
            {
                return "C:\\INTRANET\\SACC\\CertificadosPT";//Se devuelve un valor estatico ya que al ser variable de inicializacion no se debe levantar error
            }
        }

        public static string NombreAplicacion()
        {
            try
            {
                return ConfigurationManager.AppSettings["APLICACION"].ToString();
            }
            catch
            {
                return "Lafarnet-SAP";//Se devuelve un valor estatico ya que al ser variable de inicializacion no se debe levantar error
            }
        }

        #region Conexiones
        public static string ConexionBDSAP()
        {
            try
            {
                string pass = Comunes.WS_SegNet.DesEncriptarValor(ConfigurationManager.AppSettings["MC_PASSWORD"].ToString());
                return CapaDatos.GeneracionConexion.ConexionSQL(ConfigurationManager.AppSettings["MC_SERVER"].ToString(), ConfigurationManager.AppSettings["MC_BD"].ToString(), ConfigurationManager.AppSettings["MC_USUARIO"].ToString(), pass);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en parametros de cadena de conexion de aplicacion: " + ex.Message);
            }
        }
        #endregion

        #region Conexiones
        public static string ConexionBDMySQL()
        {
            try
            {
                string pass = Comunes.WS_SegNet.DesEncriptarValor(ConfigurationManager.AppSettings["LF_PASSWORD"].ToString());
                return CapaDatos.GeneracionConexionMySql.ConexionSQL(ConfigurationManager.AppSettings["LF_SERVER"].ToString(), ConfigurationManager.AppSettings["LF_BD"].ToString(), ConfigurationManager.AppSettings["LF_USUARIO"].ToString(), pass);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en parametros de cadena de conexion de aplicacion: " + ex.Message);
            }
        }
        #endregion
    }
}
