using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._02._02_Clase_Nutrición.Entidades
{
    public class Paciente
    {
        //public string PrimerNombre;
        public string PrimerNombre { get; set; } //forma corta
        private bool Beneficiario { get; set; }
        private Telefono Telefono { get; set; }
        public EstadoCivil EstadoCivil { get; set; } 
        public long NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; internal set; }
        public TipoDocumento TipoDocumento { get; internal set; }
    }
}

namespace _2018._02._02_Clase_Nutrición.Entidades
{
    public enum EstadoCivil
    {
            Soltero = 1,
            Casado = 2,
            Viudo = 3,
    }
}