using GestorAppMotorola.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class InstalacionGetDTO
    {
        public int InstalacionId { get; set; }
        public Boolean Exitosa { get; set; }
        public DateTime Fecha { get; set; }

        public int AppId { get; set; }

       public int OperarioId { get; set; }

        public int TelefonoId { get; set; }


        public App App { get; set; }

        public Operario Operario { get; set; }

        public Telefono Telefono { get; set; }

    }
}
