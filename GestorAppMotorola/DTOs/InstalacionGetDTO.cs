﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class InstalacionGetDTO
    {
        public int Id { get; set; }
        public Boolean Exitosa { get; set; }
        public DateTime Fecha { get; set; }
    }
}
