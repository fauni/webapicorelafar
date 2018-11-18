using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
    public class GeneracionConexionMySql{
        public static string ConexionSQL(string Server, string BaseDatos, string Usuario, string Password)
        {
            String conguardar = "datasource=" + Server + ";port=3306;username=" + Usuario + ";password=" + Password + ";database=" + BaseDatos + "; SslMode=none";
            return conguardar;
        }
    }

    public class ConsultaMySql
    {
        //Variable que contiene el nombre del Store Procedure
        private string NombreSP = String.Empty;
        private string sql = String.Empty;
        //Variable que contiene el error que se ocaciono
        private string MensajeError = String.Empty;

        public ConsultaMySql(string sql)
        {
            this.sql = sql;
        }

        public DataTable EjecutarConsulta(string CadenaConexion)
        {
            
            MySqlConnection conexion = new MySqlConnection(CadenaConexion);
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.CommandTimeout = 60;

            DataTable Consulta = new DataTable();
            MySqlDataReader reader;

            int count = 0;
            try
            {
                conexion.Open();
                Consulta.Load(comando.ExecuteReader());
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return Consulta;
        }


    }
}
