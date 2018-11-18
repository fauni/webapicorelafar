using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class CertificadoMPModelo
    {
        public int id_certificado_analisis { get; set; }
        public string codigo_certificado { get; set; }
        public string codigo_analista { get; set; }
        public string protocolo { get; set; }
        public DateTime fecha_analisis { get; set; }
        public string lote { get; set; }
        public DateTime fecha_fabricacion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string cantidad_fabricada { get; set; }
        public string cantidad_liberada { get; set; }
        public string tipo_certificado { get; set; }
        public string tipo_clasificacion_producto { get; set; }
        public string codigo_producto { get; set; }
        public string dictamen { get; set; }
        public string presentacion { get; set; }
        public string conservacionyalm { get; set; }
        public string referencias { get; set; }
        public string observaciones { get; set; }
        public string tipo_impresion { get; set; }
        public string nombre_producto { get; set; }
        public string concentracion { get; set; }
        public string forma_farmaceutica { get; set; }
        public string nombre_proveedor { get; set; }
        public string nombre_fabricante { get; set; }
        public string usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }

    public class ResponseCertificadoAnalisisMP
    {
        public int status { get; set; }
        public CertificadoMPModelo body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }
}
