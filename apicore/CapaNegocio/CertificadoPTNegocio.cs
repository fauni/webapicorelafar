using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelos;
using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class CertificadoPTNegocio
    {
        public List<CertificadoPTModelo>  GetDatosCertificadoPT(string codigo)
        {
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"SELECT * from sacc_certificado_analisis c
                                                            LEFT JOIN sacc_analistas a ON c.codigo_analista = a.codigo
                                                            LEFT JOIN users u ON a.username = u.username 
                                                             where c.codigo_certificado = '" + codigo + @"';");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0) 
                throw new Exception("No trajo datos de la consulta de la base de datos:");
                List<CertificadoPTModelo> listacpt = new List<CertificadoPTModelo >();
                foreach (DataRow item in dt.Rows )
                {
                    CertificadoPTModelo cpt= new CertificadoPTModelo 
                     {
                            id_certificado_analisis = Convert.ToInt32(item["id_certificado_analisis"]),
                            codigo_certificado = item["codigo_certificado"].ToString(),
                            codigo_analista = (item["codigo_analista"]).ToString(),
                            protocolo = (item["protocolo"]).ToString(),
                            fecha_analisis = Convert.ToDateTime(item["fecha_analisis"]),
                            lote = (item["lote"]).ToString(),
                            fecha_fabricacion = Convert.ToDateTime(item["fecha_fabricacion"]),
                            fecha_vencimiento = Convert.ToDateTime(item["fecha_vencimiento"]),
                            cantidad_fabricada = (item["cantidad_fabricada"]).ToString(),
                            cantidad_liberada = (item["cantidad_liberada"]).ToString(),
                            tipo_certificado = (item["tipo_certificado"]).ToString(),
                            tipo_clasificacion_producto = (item["tipo_clasificacion_producto"]).ToString(),
                            codigo_producto = (item["codigo_producto"]).ToString(),
                            dictamen = (item["dictamen"]).ToString(),
                            presentacion = (item["presentacion"]).ToString(),
                            conservacionyalm = (item["conservacionyalm"]).ToString(),
                            referencias = (item["referencias"]).ToString(),
                            observaciones = (item["observaciones"]).ToString(),
                            tipo_impresion = (item["tipo_impresion"]).ToString(),
                            nombre_producto = (item["nombre_producto"]).ToString(),
                            concentracion = (item["concentracion"]).ToString(),
                            forma_farmaceutica = (item["forma_farmaceutica"]).ToString(),
                            nombre_proveedor = (item["nombre_proveedor"]).ToString(),
                            usuario_creacion = (item["usuario_creacion"]).ToString(),
                            fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                            usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                            fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                     };
                    listacpt.Add(cpt);

                }
                return listacpt;

            }
              catch (Exception ex)
            {
                return null;
            }
        }

        public CertificadoPTModelo GetCertificadoPT(string codigo)
        {
            CertificadoPTModelo certificadopt = new CertificadoPTModelo();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"SELECT * from sacc_certificado_analisis c
                                                            LEFT JOIN sacc_analistas a ON c.codigo_analista = a.codigo
                                                            LEFT JOIN users u ON a.username = u.username 
                                                             where c.codigo_certificado = '" + codigo + @"';");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta de la base de datos:");
                
                foreach (DataRow item in dt.Rows)
                {
                    CertificadoPTModelo cpt = new CertificadoPTModelo
                    {
                        id_certificado_analisis = Convert.ToInt32(item["id_certificado_analisis"]),
                        codigo_certificado = item["codigo_certificado"].ToString(),
                        codigo_analista = (item["codigo_analista"]).ToString(),
                        protocolo = (item["protocolo"]).ToString(),
                        fecha_analisis = Convert.ToDateTime(item["fecha_analisis"]),
                        lote = (item["lote"]).ToString(),
                        fecha_fabricacion = Convert.ToDateTime(item["fecha_fabricacion"]),
                        fecha_vencimiento = Convert.ToDateTime(item["fecha_vencimiento"]),
                        cantidad_fabricada = (item["cantidad_fabricada"]).ToString(),
                        cantidad_liberada = (item["cantidad_liberada"]).ToString(),
                        tipo_certificado = (item["tipo_certificado"]).ToString(),
                        tipo_clasificacion_producto = (item["tipo_clasificacion_producto"]).ToString(),
                        codigo_producto = (item["codigo_producto"]).ToString(),
                        dictamen = (item["dictamen"]).ToString(),
                        presentacion = (item["presentacion"]).ToString(),
                        conservacionyalm = (item["conservacionyalm"]).ToString(),
                        referencias = (item["referencias"]).ToString(),
                        observaciones = (item["observaciones"]).ToString(),
                        tipo_impresion = (item["tipo_impresion"]).ToString(),
                        nombre_producto = (item["nombre_producto"]).ToString(),
                        concentracion = (item["concentracion"]).ToString(),
                        forma_farmaceutica = (item["forma_farmaceutica"]).ToString(),
                        nombre_proveedor = (item["nombre_proveedor"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    certificadopt = cpt;
                }
                return certificadopt;

            }
            catch (Exception ex)
            {
                return certificadopt;
            }
        }

        public CertificadoPTModelo GetCertificadoPTReport(string codigo)
        {
            CertificadoPTModelo certificadopt = new CertificadoPTModelo();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"SELECT * from sacc_certificado_analisis c
                                                            LEFT JOIN sacc_analistas a ON c.codigo_analista = a.codigo
                                                            LEFT JOIN users u ON a.username = u.username 
                                                             where c.codigo_certificado = '" + codigo + @"';");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta de la base de datos:");

                foreach (DataRow item in dt.Rows)
                {
                    CertificadoPTModelo cpt = new CertificadoPTModelo
                    {
                        id_certificado_analisis = Convert.ToInt32(item["id_certificado_analisis"]),
                        codigo_certificado = item["codigo_certificado"].ToString(),
                        codigo_analista = (item["grado"]).ToString() + " " + (item["first_name"]).ToString() + " " + (item["last_name"]).ToString(),
                        protocolo = (item["protocolo"]).ToString(),
                        fecha_analisis = Convert.ToDateTime(item["fecha_analisis"]),
                        lote = (item["lote"]).ToString(),
                        fecha_fabricacion = Convert.ToDateTime(item["fecha_fabricacion"]),
                        fecha_vencimiento = Convert.ToDateTime(item["fecha_vencimiento"]),
                        cantidad_fabricada = (item["cantidad_fabricada"]).ToString(),
                        cantidad_liberada = (item["cantidad_liberada"]).ToString(),
                        tipo_certificado = (item["tipo_certificado"]).ToString(),
                        tipo_clasificacion_producto = (item["tipo_clasificacion_producto"]).ToString(),
                        codigo_producto = (item["codigo_producto"]).ToString(),
                        dictamen = (item["dictamen"]).ToString(),
                        presentacion = (item["presentacion"]).ToString(),
                        conservacionyalm = (item["conservacionyalm"]).ToString(),
                        referencias = (item["referencias"]).ToString(),
                        observaciones = (item["observaciones"]).ToString(),
                        tipo_impresion = (item["tipo_impresion"]).ToString(),
                        nombre_producto = (item["nombre_producto"]).ToString(),
                        concentracion = (item["concentracion"]).ToString(),
                        forma_farmaceutica = (item["forma_farmaceutica"]).ToString(),
                        nombre_proveedor = (item["nombre_proveedor"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    certificadopt = cpt;
                }
                return certificadopt;

            }
            catch (Exception ex)
            {
                return certificadopt;
            }
        }
    }
}
