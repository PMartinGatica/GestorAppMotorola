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
    public class InstalacionController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public InstalacionController(ApplicationDBContext context , IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<InstalacionGetDTO>>> Get()
        {
            var inst = await context.operario.ToListAsync();
            return mapper.Map<List<InstalacionGetDTO>>(inst);
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<InstalacionGetDTO>> Get(int id)
        {
            var oper = await context.Instalacion.FirstOrDefaultAsync(x => x.Id == id);

            if (oper == null)
            {
                return NotFound();
            }

            return mapper.Map<InstalacionGetDTO>(oper);
        }

        //[HttpPost]

        //public async Task<ActionResult> Post(Instalacion Instalacion)
        //{


        //    context.Add(Instalacion);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Instalacion Instalacion, int id)
        {
            if (Instalacion.Id != id)
            {
                return BadRequest("El id de la instalacion no coincide con el id de la URL");
            }

            var yaexiste = await context.Instalacion.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return NotFound($"No la instalacion con el id {Instalacion.Id}");
            }

            //context.Entry(Instalacion).State = EntityState.Modified;
            context.Update(Instalacion);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

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
