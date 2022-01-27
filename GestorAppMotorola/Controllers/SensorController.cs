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

        //[HttpGet("{nombre}")]
        //public async Task<ActionResult<List<Sensor>>> Get(string nombre)
        //{
        //    var Sensors = await context.Sensor.Where(x => x.Nombre.Contains(nombre)).ToListAsync();

        //    return Sensors;
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<SensorGetDTO>> GetSensor(int id)
        //{
        //    var oper = await context.Sensor.Include(x => x.Instalacion).FirstOrDefaultAsync(x => x.Id == id);

        //    if (oper == null)
        //    {
        //        return NotFound();
        //    }

        //    return mapper.Map<SensorGetDTO>(oper);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<SensorGetDTO>> GetSensor(int id)
        {
            var sen = await context.Sensor
                
                .Include(telefonoDB => telefonoDB.SensorTelefono)
                .ThenInclude(sensortelefonoDB => sensortelefonoDB.Sensor)
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
            if (SensorCreacionDTO.TelefonoIds == null)
            {
                return BadRequest("No se puede crear un sensores sin telefonos");
            }
            var telefonoIds = await context.Telefono.
                Where(telefonodb => SensorCreacionDTO.TelefonoIds.Contains(telefonodb.TelefonoId)).Select(x => x.TelefonoId).ToListAsync();

            if (SensorCreacionDTO.TelefonoIds.Count != telefonoIds.Count)
            {
                return BadRequest("No existe uno de los Sensores Eviados");
            }

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
