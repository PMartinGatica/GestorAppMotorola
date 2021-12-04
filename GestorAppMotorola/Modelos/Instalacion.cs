using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Modelos
{
    public class Instalacion
    {
        public int Id { get; set; }
        public Boolean Exitosa { get; set; }
        public DateTime Fecha { get; set; }

        public App app { get; set; }
        public Operario operario { get; set; }



    }
}
