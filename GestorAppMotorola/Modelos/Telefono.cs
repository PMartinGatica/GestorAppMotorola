using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Modelos
{
    public class Telefono
    {
        public int TelefonoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }

        public List <SensorTelefono>SensorTelefono { get; set; }
        public List<Instalacion> Instalaciones { get; set; }
       // public List<Sensor> Sensores { get; set; }

    }
}
