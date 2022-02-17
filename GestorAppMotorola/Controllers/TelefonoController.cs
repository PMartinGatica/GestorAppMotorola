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
    public class TelefonoController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public TelefonoController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonoGetDTOGeneral>>> Telefonos()
        {
            var tel = await context.Telefono
                .Include(dbtelefono => dbtelefono.Instalaciones)

                .ThenInclude(dbapp => dbapp.App)
                .Include(telefonoDB => telefonoDB.SensorTelefono)
                .ThenInclude(sensortelefonoDB => sensortelefonoDB.Sensor)

                .ToListAsync();
            return mapper.Map<List<TelefonoGetDTOGeneral>>(tel);
        }


        [HttpGet("sensores")]
        public async Task<ActionResult<IEnumerable<TelefonoDTOConSensores>>> sensores()
        {
            var tel = await context.Telefono
                .Include(dbtelefono => dbtelefono.Instalaciones)

                .ThenInclude(dbapp=>dbapp.App)
                .Include(telefonoDB => telefonoDB.SensorTelefono)
                .ThenInclude(sensortelefonoDB => sensortelefonoDB.Sensor)

                .ToListAsync();
            return mapper.Map<List<TelefonoDTOConSensores>>(tel);
        }

        
        


        [HttpGet("{id}")]
        public async Task<ActionResult<TelefonoDTOConInstalaciones>> GetTelefono(int id)
        {
            var tel = await context.Telefono
                .Include(dbtelefono => dbtelefono.Instalaciones).ThenInclude(x=>x.App)
                .Include(dbtelefono => dbtelefono.Instalaciones).ThenInclude(x => x.Operario)
             
                //.Include(telefonoDB => telefonoDB.SensorTelefono)
                //.ThenInclude(sensortelefonoDB => sensortelefonoDB.Sensor)
                .FirstOrDefaultAsync(x => x.TelefonoId == id);


            
            return mapper.Map<TelefonoDTOConInstalaciones>(tel);
        }


        [HttpGet("FiltroSensor_App")]
        public dynamic FiltroSensor_App(string sensor , string aplicacion)
        {

            return context.Instalacion
                .Where(item => item.App.Nombre == aplicacion)
                .Select(item => new
                {
                    aplicacion = item.App.Nombre,
                    sensor = item.Telefono.SensorTelefono.Where(item=>item.Sensor.Nombre ==sensor)
                    .Select(item => new {
                    item.Sensor.Nombre,
                    Telefono = item.Telefono.Marca
                    
                    }
                    )
                })
                .ToList();
        }


        [HttpPost]

        public async Task<ActionResult<Telefono>> PostTelefono(TelefonoCreacionDTO TelefonoCreacionDTO)
        {
            if (TelefonoCreacionDTO.SensoresIds == null)
            {
                return BadRequest("No se puede crear un telefono sin sensores");
            }
            var sensoresIds = await context.Sensor.
                Where(sensordb => TelefonoCreacionDTO.SensoresIds.Contains(sensordb.SensorId)).Select(x=>x.SensorId).ToListAsync();

            if (TelefonoCreacionDTO.SensoresIds.Count != sensoresIds.Count)
            {
                return BadRequest("No existe uno de los Sensores Eviados");
            }

            var tel = mapper.Map<Telefono>(TelefonoCreacionDTO);

            context.Telefono.Add(tel);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetTelefono", new { id = tel.TelefonoId }, tel);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutOperacion(Telefono Telefono, int id)
        {
            if (Telefono.TelefonoId != id)
            {
                return BadRequest("El id del Telefono no coincide con el id de la URL");
            }

            context.Entry(Telefono).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoExiste(id))
                {
                    return NotFound($"No existe el Telefono con el id {Telefono.TelefonoId}");
                }

                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteTelefono(int id)
        {
            var tel = await context.Telefono.FindAsync(id);

            if (tel == null)
            {
                return NotFound();
            }

            context.Telefono.Remove(tel);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool TelefonoExiste(int id)
        {
            return context.Telefono.Any(x => x.TelefonoId == id);
        }

    }
}