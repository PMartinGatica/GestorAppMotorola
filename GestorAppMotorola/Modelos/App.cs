using GestorAppMotorola.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Modelos
{
    public class App
    {
        public int AppId { get; set; }
        public string Nombre { get; set; }

        public  List<Instalacion> Instalaciones { get; set; }

    }
}
