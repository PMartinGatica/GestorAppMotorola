using AutoMapper;
using GestorAppMotorola.DTOs;
using GestorAppMotorola.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<OperarioCreacionDTO, operario>();
            CreateMap<operario, OperarioGetDTO>();
            CreateMap<AppCreacionDTO, App>();
            CreateMap<App, AppGetDTO>();
            CreateMap<Instalacion , InstalacionGetDTO>();
        }
    }
}
