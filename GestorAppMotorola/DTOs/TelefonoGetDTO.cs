using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class TelefonoGetDTO
    {
        public int TelefonoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }
        public List<SensorGetDTO> Sensor { get; set; }

        //public virtual ICollection<SensorGetDTO> Sensor { get; set; }
        public List<InstalacionGetDTO> Instalaciones { get; set; }


    }
}
