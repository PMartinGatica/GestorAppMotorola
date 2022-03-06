using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Modelos
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string Nombre { get; set; }

        public List <SensorTelefono>SensorTelefono { get; set; }

        

    }
}
