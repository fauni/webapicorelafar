using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelos
{
    public class PersonaVacacion
    {
        public int empid { get; set; }
        public string empleado { get; set; }
        public string cargo { get; set; }
        public string fecha_ingreso { get; set; }
        public string fecha { get; set; }
        public float numdias { get; set; }
        public float ant { get; set; }
        public float saldo { get; set; }
        public float saldo_total { get; set; }
        public float duodecima { get; set; }
	    public string oficina { get; set; }
        public string area { get; set; }
    }

    public class PersonaZofraVacacion
    {
        public int userid { get; set; }
        public int idsap { get; set; }
        public string Personal { get; set; }
        public float total { get; set; }
    }

    public class ResponsePersonaVacacion
    {
        public int status { get; set; }
        public List<PersonaVacacion> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
    }

    public class ResponsePersonaVacacionZofra
    {
        public int status { get; set; }
        public List<PersonaZofraVacacion> body { get; set; }
        public int length { get; set; }
        public string message { get; set; }
        public List<PersonaZofraVacacion> data { get; set; }
    }
}
