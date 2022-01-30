using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class TelefonoGetDTOId
    {
        public int TelefonoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }


        //public virtual ICollection<SensorGetDTO> Sensor { get; set; }
        public List<InstalacionGetDTO> Instalaciones { get; set; }


    }
}
