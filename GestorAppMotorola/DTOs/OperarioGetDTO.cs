using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class OperarioGetDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<InstalacionGetDTO>Instalaciones { get; set; }
    }
}
