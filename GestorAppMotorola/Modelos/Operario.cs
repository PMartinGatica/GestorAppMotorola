using GestorAppMotorola.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Modelos
{
    public class Operario
    {
        public int OperarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public List<Instalacion> Instalaciones { get; set; }

    }
}
