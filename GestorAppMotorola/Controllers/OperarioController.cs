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
    public class OperarioController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public OperarioController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Operario>>> Get()
        {
            return await context.Operario.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult> Post(Operario Operario)
        {
            var yaexiste = await context.Operario.AnyAsync(x => x.Nombre == Operario.Nombre);

            if (yaexiste)
            {
                return BadRequest($"Ya existe el nombre {Operario.Nombre}");
            }

            context.Add(Operario);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Operario operario, int id)
        {
            if (operario.Id != id)
            {
                return BadRequest("El id del Operario no coincide con el id de la URL");
            }

            var yaexiste = await context.Operario.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return NotFound($"No existe el Operario con el id {operario.Id}");
            }

            
            context.Update(operario);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id=int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var yaexiste = await context.Operario.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return BadRequest();
            }

            context.Remove(new Operario() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
