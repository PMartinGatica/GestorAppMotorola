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
    public class InstalacionController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public InstalacionController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Instalacion>>> Get()
        {
            return await context.Instalacion.ToListAsync();
        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<Instalacion>> Get(int id)
        {
            var inst = await context.Instalacion.FirstOrDefaultAsync(x => x.Id == id);
            if (inst == null)
            {
                return NotFound($"No existe Instalacion con la id {inst.Id}");
            }

            return inst;
        }

        [HttpPost]

        public async Task<ActionResult> Post(Instalacion Instalacion)
        {
            ////var yaexiste = await context.Instalacion.AnyAsync(x => x.Nombre == Instalacion.Nombre);

            ////if (yaexiste)
            ////{
            ////    return BadRequest($"Ya existe el nombre {Instalacion.Nombre}");
            ////}

            context.Add(Instalacion);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Instalacion Instalacion, int id)
        {
            if (Instalacion.Id != id)
            {
                return BadRequest("El id del Operario no coincide con el id de la URL");
            }

            var yaexiste = await context.Instalacion.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return NotFound($"No existe el Operario con el id {Instalacion.Id}");
            }

            //context.Entry(Instalacion).State = EntityState.Modified;
            context.Update(Instalacion);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id=int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var yaexiste = await context.Instalacion.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return BadRequest();
            }

            context.Remove(new Instalacion() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
