﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class AppDTOConInstalaciones:AppGetDTO
    {
        public List<InstalacionesDTOConApp> Instalaciones { get; set; }
    }
}
