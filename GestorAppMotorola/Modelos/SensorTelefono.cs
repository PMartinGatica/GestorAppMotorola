using GestorAppMotorola.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Modelos
{
    public class SensorTelefono
    {
        public int SensorId { get; set; }
        public int TelefonoId { get; set; }
        public Sensor Sensor { get; set; }
        public Telefono Telefono { get; set; }

       


    }
}
