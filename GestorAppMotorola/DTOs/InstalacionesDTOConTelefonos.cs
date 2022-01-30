using GestorAppMotorola.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class InstalacionesDTOConTelefonos:InstalacionGetDTO
    {
        public int TelefonoId { get; set; }
        public TelefonoGetDTO Telefono { get; set; }

        public int AppId { get; set; }
        public AppGetDTO App { get; set; }

        public int OperarioId { get; set; }
        public OperarioGetDTO Operario { get; set; }
    }
}
