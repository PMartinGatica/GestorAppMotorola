using AutoMapper;
using GestorAppMotorola.DTOs;
using GestorAppMotorola.Modelos;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<SensorGetDTO>>> GetSensor()
        {
            var sen = await context.Sensor.ToListAsync();
            return mapper.Map<List<SensorGetDTO>>(sen);
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<SensorGetDTO>> GetSensor(int id)
        {
            var sen = await context.Sensor
                
                .Include(telefonoDB => telefonoDB.SensorTelefono)
                .ThenInclude(sensortelefonoDB => sensortelefonoDB.Telefono)
                .FirstOrDefaultAsync(x=>x.SensorId==id);


            if (sen == null)
            {
                return NotFound();
            }

            return mapper.Map<SensorGetDTO>(sen);
        }


        [HttpPost]

        public async Task<ActionResult<Sensor>> PostSensor(SensorCreacionDTO SensorCreacionDTO)
        {
            

            var sen = mapper.Map<Sensor>(SensorCreacionDTO);

            context.Sensor.Add(sen);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetSensor", new { id = sen.SensorId }, sen);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutOperacion(Sensor Sensor, int id)
        {
            if (Sensor.SensorId != id)
            {
                return BadRequest("El id del Sensor no coincide con el id de la URL");
            }

            context.Entry(Sensor).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExiste(id))
                {
                    return NotFound($"No existe el Sensor con el id {Sensor.SensorId}");
                }

                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteSensor(int id)
        {
            var sen = await context.Sensor.FindAsync(id);

            if (sen == null)
            {
                return NotFound();
            }

            context.Sensor.Remove(sen);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool SensorExiste(int id)
        {
            return context.Sensor.Any(x => x.SensorId == id);
        }

    }
}
