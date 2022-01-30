using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class SensorDTOConTelefonos: SensorGetDTO
    {
        public List<TelefonoGetDTO> Telefono { get; set; }
    }
}
