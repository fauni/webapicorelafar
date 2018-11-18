using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using CapaNegocio;
using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class CaracteristicasCertificadoNegocio
    {
        public List<CaracteristicaCertificadoModelo> GetDatosCaracteristicas(string codigo)
        {
            List<CaracteristicaCertificadoModelo> listacar = new List<CaracteristicaCertificadoModelo>();
            try
            {        
                ConsultaMySql consulta = new ConsultaMySql (@"
                    SELECT cc.id_certificado_caracteristica, cc.codigo_certificado, codigo_producto, cc.id_caracteristica, cc.especificacion, cc.resultado, cc.estado, cc.tipo_caracteristica, cc.usuario_creacion, cc.fecha_creacion, cc.usuario_modificacion, cc.fecha_modificacion, cc.orden
                    from newlafarnet.sacc_certificado_caracteristica cc
                    where codigo_certificado='" + codigo+ @"' and tipo_caracteristica='CF'
                    union
                    SELECT cc.id_certificado_caracteristica, cc.codigo_certificado, codigo_producto, cc.id_caracteristica, cc.especificacion, cc.resultado, cc.estado, cc.tipo_caracteristica, cc.usuario_creacion, cc.fecha_creacion, cc.usuario_modificacion, cc.fecha_modificacion, cc.orden
                    from newlafarnet.sacc_certificado_caracteristica cc
                    where codigo_certificado='" + codigo+ @"' and tipo_caracteristica='AQ'
                    union
                    SELECT cc.id_certificado_caracteristica, cc.codigo_certificado, codigo_producto, cc.id_caracteristica, cc.especificacion, cc.resultado, cc.estado, cc.tipo_caracteristica, cc.usuario_creacion, cc.fecha_creacion, cc.usuario_modificacion, cc.fecha_modificacion, cc.orden
                    from newlafarnet.sacc_certificado_caracteristica cc
                    where codigo_certificado='" + codigo+@"' and tipo_caracteristica='CM' ;");
                DataTable dt = consulta.EjecutarConsulta (Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <=0)
                    throw new Exception ("No trajo datos  de la consulta de la base de datos");
                
                foreach (DataRow  item in dt.Rows)
                {
                    CaracteristicaCertificadoModelo car = new CaracteristicaCertificadoModelo
                    {
                        codigo_producto = (item["codigo_producto"]).ToString(),
                        id_caracteristica = (item["id_caracteristica"]).ToString(),
                        especificacion = (item["especificacion"]).ToString(),
                        resultado = (item["resultado"]).ToString(),
                        tipo_caracteristica = (item["tipo_caracteristica"]).ToString(),
                        estado = Convert.ToInt32(item["estado"]),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"]),
                        orden = Convert.ToInt32(item["orden"])
                    };
                    listacar.Add(car);
                }  
                return listacar;   
            }
            catch (Exception ex)
            {
                return listacar;
            }
        }

        public List<CaracteristicaCertificadoModelo> GetList(string codigo)
        {
            List<CaracteristicaCertificadoModelo> listacar = new List<CaracteristicaCertificadoModelo>();
            try
            {        
                ConsultaMySql consulta = new ConsultaMySql (@"
                        SELECT cc.id_certificado_caracteristica, cc.codigo_certificado, codigo_producto, cf.descripcion as 'id_caracteristica', cc.especificacion, cc.resultado, cc.estado, cc.tipo_caracteristica, cc.usuario_creacion, cc.fecha_creacion, cc.usuario_modificacion, cc.fecha_modificacion, cc.orden
                        from sacc_certificado_caracteristica cc
                        inner join sacc_productos_caracteristicas_fisicas cf on cc.id_caracteristica = cf.id_caracteristicas_fisicas
                        where codigo_certificado='" + codigo + @"' and tipo_caracteristica='CF'
                        union
                        SELECT cc.id_certificado_caracteristica, cc.codigo_certificado, codigo_producto, cf.descripcion as 'id_caracteristica', cc.especificacion, cc.resultado, cc.estado, cc.tipo_caracteristica, cc.usuario_creacion, cc.fecha_creacion, cc.usuario_modificacion, cc.fecha_modificacion, cc.orden
                        from sacc_certificado_caracteristica cc
                        inner join sacc_productos_analisis_quimico cf on cc.id_caracteristica = cf.id_analisis_quimico
                        where codigo_certificado='" + codigo + @"' and tipo_caracteristica='AQ'
                        union
                        SELECT cc.id_certificado_caracteristica, cc.codigo_certificado, codigo_producto, cf.descripcion as 'id_caracteristica', cc.especificacion, cc.resultado, cc.estado, cc.tipo_caracteristica, cc.usuario_creacion, cc.fecha_creacion, cc.usuario_modificacion, cc.fecha_modificacion, cc.orden
                        from sacc_certificado_caracteristica cc
                        inner join sacc_productos_analisis_microbiologico cf on cc.id_caracteristica = cf.id_analisis_microbiologico
                        where codigo_certificado='" + codigo + @"' and tipo_caracteristica='CM' ;                    
                ");
                DataTable dt = consulta.EjecutarConsulta (Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <=0)
                    throw new Exception ("No trajo datos  de la consulta de la base de datos");
                
                foreach (DataRow  item in dt.Rows)
                {
                    CaracteristicaCertificadoModelo car = new CaracteristicaCertificadoModelo
                    {
                        codigo_producto = (item["codigo_producto"]).ToString(),
                        id_caracteristica = (item["id_caracteristica"]).ToString(),
                        especificacion = (item["especificacion"]).ToString(),
                        resultado = (item["resultado"]).ToString(),
                        tipo_caracteristica = (item["tipo_caracteristica"]).ToString(),
                        estado = Convert.ToInt32(item["estado"]),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"]),
                        orden = Convert.ToInt32(item["orden"])
                    };
                    listacar.Add(car);
                }  
                return listacar;   
            }
            catch (Exception ex)
            {
                return listacar;
            }
        }
        
        public Boolean Add(CaracteristicaModelo c)
        {
            try
            {
                String sql = @"INSERT INTO newlafarnet.sacc_certificado_caracteristica (codigo_certificado, codigo_producto, id_caracteristica, especificacion, resultado, estado, tipo_caracteristica, usuario_creacion, fecha_creacion, usuario_modificacion, fecha_modificacion) VALUES('"+ c.codigo_certificado +"','"+ c.codigo_producto +"','"+ c.id_caracteristica +"','"+c.especificacion+"','"+c.resultado+"','"+c.estado+"','"+c.tipo_caracteristica+"','"+c.usuario_creacion+"',now(),'"+c.usuario_modificacion+"',now())";
                ConsultaMySql consulta = new ConsultaMySql(sql);
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean Anular(string codigo_certificado)
        {
            try
            {
                String sql = @"UPDATE newlafarnet.sacc_certificado_analisis set dictamen = 'ANULADO' where codigo_certificado = '"+codigo_certificado+@"';";
                ConsultaMySql consulta = new ConsultaMySql(sql);
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}





 


                           
