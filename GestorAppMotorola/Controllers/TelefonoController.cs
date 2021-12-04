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
        public async Task<ActionResult<List<Telefono>>> Get()
        {
            return await context.Telefono.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Telefono>> Get(int id)
        {
            var telefonoOK = await context.Telefono.FirstOrDefaultAsync(x => x.Id == id);
            if (telefonoOK == null)
            {
                return NotFound();
            }
            return telefonoOK;
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
                return NotFound($"No existe el telefono con el id {telefono.Id}");
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
