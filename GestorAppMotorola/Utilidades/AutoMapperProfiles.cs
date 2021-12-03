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
        }
    }
}
