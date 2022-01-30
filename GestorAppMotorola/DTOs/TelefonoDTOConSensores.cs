using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class TelefonoDTOConSensores:TelefonoGetDTO
    {
        public List<SensorGetDTO> Sensor { get; set; }
    }
}
