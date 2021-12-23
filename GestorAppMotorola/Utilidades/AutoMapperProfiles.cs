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
            CreateMap<OperarioCreacionDTO, Operario>();
            CreateMap<Operario, OperarioGetDTO>();
            CreateMap<AppCreacionDTO, App>();
            CreateMap<App, AppGetDTO>();
            CreateMap<InstalacionCreacionDTO, Instalacion>();
            CreateMap<Instalacion , InstalacionGetDTO>();
            CreateMap<SensorCreacionDTO,Sensor>();
            CreateMap<Sensor, SensorGetDTO>();
            CreateMap<TelefonoCreacionDTO, Telefono>();
            CreateMap<Telefono, TelefonoGetDTO>();

        }
    }
}
