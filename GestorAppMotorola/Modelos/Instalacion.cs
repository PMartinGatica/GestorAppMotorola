using GestorAppMotorola.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Modelos
{
    public class Instalacion
    {
        public int Id { get; set; }
        public Boolean Exitosa { get; set; }
        public DateTime Fecha { get; set; }

        public int AppId { get; set; }

        public int OperarioId { get; set; }


        // public List<Operario> operarios { get; set; }
        public List<App>App{ get; set; }

        public List<Operario> Operario { get; set; }


    }
}
