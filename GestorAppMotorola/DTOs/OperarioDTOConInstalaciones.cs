using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class OperarioDTOConInstalaciones:OperarioGetDTO
    {
        public List<InstalacionesDTOConTelefonos> Instalaciones { get; set; }
    }
}
