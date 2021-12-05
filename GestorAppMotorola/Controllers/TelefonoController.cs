using AutoMapper;
using GestorAppMotorola.Dtos;
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
    [Route("api/[controller]")]
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
        public async Task<ActionResult<List<TelefonoDTO>>> GetAll()
        {
            var telefonos = await context.Telefono.ToListAsync();
            return mapper.Map<List<TelefonoDTO>>(telefonos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TelefonoDTO>> GetByID(int id)
        {
            var telefono = await context.Telefono.FirstOrDefaultAsync(x => x.Id == id);

            if (telefono == null)
            {
                return NotFound($"No existe el telefono con ID : {telefono.Id}");
            }
            return mapper.Map<TelefonoDTO>(telefono);
        }

        [HttpGet("{modelo}")]
        public async Task<ActionResult<List<TelefonoDTO>>> GetByModelo([FromRoute] string modelo)
        {
            var modelos = await context.Telefono.Where(x => x.Modelo.Contains(modelo)).ToListAsync();

            return mapper.Map<List<TelefonoDTO>>(modelos);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreacionTelefonoDTO creacionTelefonoDTO)
        {
            var telefonoOK = await context.Telefono.AnyAsync(x => x.Modelo == creacionTelefonoDTO.Modelo);

            if (telefonoOK)
            {
                return BadRequest($"Ya existe un telefono moodelo {creacionTelefonoDTO.Modelo}");
            }

            var telefono = mapper.Map<Telefono>(creacionTelefonoDTO);

            context.Add(telefono);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Telefono telefono, int id)
        {
            if (telefono.Id != id)
            {
                return BadRequest("El ID del telefono no coincide con el ID de la URL");
            }

            var telefonoOK = await context.Telefono.AnyAsync(x => x.Id == id);

            if (!telefonoOK)
            {
                return NotFound($"No existe el telefono con el ID : {telefono.Id}");
            }

            context.Update(telefono);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id=int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var telefonoOK = await context.Telefono.AnyAsync(x => x.Id == id);
            
            if (!telefonoOK)
            {
                return BadRequest("El ID del telefono no existe");
            }

            context.Remove(new Telefono() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
