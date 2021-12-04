using GestorAppMotorola.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class AppGetDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<InstalacionGetDTO> Instalaciones { get; set; }

    }
}
