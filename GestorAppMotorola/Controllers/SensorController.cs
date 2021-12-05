using AutoMapper;
using GestorAppMotorola.Dtos;
using GestorAppMotorola.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper; 

        public SensorController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SensorDTO>>> Get()
        {
            var sensores = await context.Sensor.ToListAsync();
            return mapper.Map<List<SensorDTO>>(sensores);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<SensorDTO>> Get(int id)
        {
           var sensorOK = await context.Sensor.FirstOrDefaultAsync(x => x.Id == id);

           if (sensorOK == null)
            {
                return NotFound($"No existe el sensor con ID: {sensorOK.Id}");
            }

            return mapper.Map<SensorDTO>(sensorOK);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreacionSensorDTO creacionSensorDTO)
        {
            var sensorOK = await context.Sensor.AnyAsync(x => x.Nombre == creacionSensorDTO.Nombre);

            if (sensorOK)
            {
                return BadRequest($"Ya existe un sensor con el nombre {creacionSensorDTO.Nombre}");
            }

            var sensor = mapper.Map<Sensor>(creacionSensorDTO);

            context.Add(sensor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Sensor sensor, int id)
        {
            if (sensor.Id != id)
            {
                return BadRequest("El ID del sensor no coincide con el ID de la URL");
            }

            var sensorOK = await context.Sensor.AnyAsync(x => x.Id == id);

            if (!sensorOK)
            {
                return NotFound($"No existe el sensor con el id {sensor.Id}");
            }

            context.Update(sensor);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id=int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sensorOK = await context.Sensor.AnyAsync(x => x.Id == id);

            if (!sensorOK)
            {
                return BadRequest("El ID del sensor no existe");
            }

            context.Remove(new Sensor() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
