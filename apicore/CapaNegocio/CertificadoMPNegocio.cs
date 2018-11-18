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
    public class CertificadoMPNegocio
    {
        public List<CertificadoMPModelo> GetDatosCertificadoMP(string codigo)
        {
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"SELECT * from sacc_certificado_analisis c
                                                            LEFT JOIN sacc_analistas a ON c.codigo_analista = a.codigo
                                                            LEFT JOIN users u ON a.username = u.username 
                                                             where c.codigo_certificado = '" + codigo + @"';");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:"); // + consulta.Error);

                List<CertificadoMPModelo> listacmp = new List<CertificadoMPModelo>();
                foreach (DataRow item in dt.Rows)
                {
                    CertificadoMPModelo cmp = new CertificadoMPModelo
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
                        nombre_fabricante = (item["nombre_fabricante"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    listacmp.Add(cmp);
                }
                return listacmp;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return null;
            }

        }


        public CertificadoMPModelo GetCertificadoMP(string codigo)
        {
            CertificadoMPModelo certificado = new CertificadoMPModelo();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"SELECT * from sacc_certificado_analisis c
                                                            LEFT JOIN sacc_analistas a ON c.codigo_analista = a.codigo
                                                            LEFT JOIN users u ON a.username = u.username 
                                                             where c.codigo_certificado = '" + codigo + @"';");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:"); // + consulta.Error);

                List<CertificadoMPModelo> listacmp = new List<CertificadoMPModelo>();
                
                foreach (DataRow item in dt.Rows)
                {
                    CertificadoMPModelo cmp = new CertificadoMPModelo
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
                        nombre_fabricante = (item["nombre_fabricante"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    //listacmp.Add(cmp);
                    certificado = cmp;
                }
                return certificado;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return certificado;
            }

        }


        public CertificadoMPModelo GetCertificadoMPReport(string codigo)
        {
            CertificadoMPModelo certificado = new CertificadoMPModelo();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"SELECT * from sacc_certificado_analisis c
                                                            LEFT JOIN sacc_analistas a ON c.codigo_analista = a.codigo
                                                            LEFT JOIN users u ON a.username = u.username 
                                                             where c.codigo_certificado = '" + codigo + @"';");
                //StoreProcedure consulta = new StoreProcedure("sp_GetPersona");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos de la consulta a la DB:"); // + consulta.Error);

                List<CertificadoMPModelo> listacmp = new List<CertificadoMPModelo>();

                foreach (DataRow item in dt.Rows)
                {
                    CertificadoMPModelo cmp = new CertificadoMPModelo
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
                        nombre_fabricante = (item["nombre_fabricante"]).ToString(),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    //listacmp.Add(cmp);
                    certificado = cmp;
                }
                return certificado;
            }
            catch (Exception ex)
            {
                //log.RegistroLogAlerta("GetSolFiltro: " + ex.ToString());
                return certificado;
            }

        }

    }
}
