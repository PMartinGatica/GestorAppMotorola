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
        public SensorController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sensor>>> Get()
        {
            return await context.Sensor.ToListAsync();
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Sensor>> Get(int id)
        {
           var sensorOK = await context.Sensor.FirstOrDefaultAsync(x => x.Id == id);
           if (sensorOK == null)
            {
                return NotFound();
            }
            return sensorOK;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Sensor sensor)
        {
            var sensorOK = await context.Sensor.AnyAsync(x => x.Nombre == sensor.Nombre);

            if (sensorOK)
            {
                return BadRequest($"No existe un sensor con el nombre {sensor.Nombre}");
            }

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
