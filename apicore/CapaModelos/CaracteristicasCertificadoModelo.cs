using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class CaracteristicaCertificadoModelo
    {
        public string codigo_producto {get;set; }
        public string id_caracteristica {get;set; }
        public string especificacion {get;set; }
        public string resultado {get;set; }
        public string tipo_caracteristica {get;set; }
        public int estado {get;set; }
        public string usuario_creacion {get;set; }
        public DateTime fecha_creacion {get;set; }
        public string usuario_modificacion {get;set; }
        public DateTime fecha_modificacion {get;set; }
        public int orden { get; set; }
    }


     public class ResponseCaracteristicas
     {
         public int status { get; set; }
         public List<CaracteristicaCertificadoModelo> body { get; set; }
         public int length { get; set; }
         public string message { get; set; }
     }

     public class ResponseCaracteristica
     {
         public int status { get; set; }
         public CaracteristicaModelo body { get; set; }
         public int length { get; set; }
         public string message { get; set; }
     }

     public class CaracteristicaModelo
     {
         public string codigo_certificado { get; set; }
         public string codigo_producto { get; set; }
         public string id_caracteristica { get; set; }
         public string descripcion { get; set; }
         public string especificacion { get; set; }
         public string resultado { get; set; }
         public string tipo_caracteristica { get; set; }
         public int estado { get; set; }
         public string usuario_creacion { get; set; }
         public DateTime fecha_creacion { get; set; }
         public string usuario_modificacion { get; set; }
         public DateTime fecha_modificacion { get; set; }
         public int orden { get; set; }
     }
}
