using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class OperarioGetDTO
    {
        public int OperarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //public List<InstalacionGetDTO>Instalaciones { get; set; }
    }
}
