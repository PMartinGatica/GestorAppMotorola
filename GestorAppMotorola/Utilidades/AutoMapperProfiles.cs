﻿using AutoMapper;
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
            CreateMap<Sensor, SensorGetDTO>()
                  .ForMember(SensorGetDTO => SensorGetDTO.Telefono, opciones => opciones.MapFrom(MapSensorDTOTelefono));
            CreateMap<TelefonoCreacionDTO, Telefono>()
                .ForMember(telefono => telefono.SensorTelefono, opciones => opciones.MapFrom(MapSensorTelefono));
            CreateMap<Telefono, TelefonoGetDTO>()
                .ForMember(telefonoGetDTO => telefonoGetDTO.Sensor, opciones => opciones.MapFrom(MapTelefonoDTOSensor));
        }

        private List<TelefonoGetDTO> MapSensorDTOTelefono(Sensor sensor, SensorGetDTO sensorGetDTO)
        {
            var resultado = new List<TelefonoGetDTO>();

            if (sensor.SensorTelefono == null) { return resultado; }

            foreach (var telefonosensor in sensor.SensorTelefono)
            {
             resultado.Add(new TelefonoGetDTO()
                {
                    TelefonoId = telefonosensor.Telefono.TelefonoId,
                    Marca = telefonosensor.Telefono.Marca,
                    Modelo = telefonosensor.Telefono.Modelo,
                    Precio = telefonosensor.Telefono.Precio,
                });
            }
            return resultado;
        }
        private List<SensorGetDTO>MapTelefonoDTOSensor(Telefono telefono, TelefonoGetDTO telefonoGetDTO)
        {
            var resultado = new List<SensorGetDTO>();

            if(telefono.SensorTelefono == null) { return resultado; }

            foreach (var sensortelefono in telefono.SensorTelefono)
            {
                resultado.Add(new SensorGetDTO()
                {
                    SensorId = sensortelefono.SensorId,
                    Nombre = sensortelefono.Sensor.Nombre
                });
            }
            return resultado;
        }

        private List<SensorTelefono>MapSensorTelefono(TelefonoCreacionDTO telefonoCreacionDTO,Telefono telefono)
        {
            var resultado = new List<SensorTelefono>();

            if (telefonoCreacionDTO.SensoresIds == null) { return resultado; }

            foreach (var sensorId in telefonoCreacionDTO.SensoresIds)
            {
                resultado.Add(new SensorTelefono() { SensorId = sensorId });
            }

            return resultado;
        }
    }
}
