using GestorAppMotorola.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        
        [NotMapped]
        public virtual SensorTelefono SensoresTelefonos { get; set; }
        [NotMapped]
        public virtual Sensor Sensores { get; set; }
        [NotMapped]
        public virtual Instalacion Instala { get; set; }



    }
}
