using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class SensorCreacionDTO
    {
        public int SensorId { get; set; }
        public string Nombre { get; set; }

        public List<int> TelefonoIds { get; set; }
    }
}
