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
    public class OperarioController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public OperarioController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Operario>>> Get()
        {
            return await context.operario.ToListAsync();
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Operario>>> Get(string nombre)
        {
            var operarios = await context.operario.Where(x => x.Nombre.Contains(nombre)).ToListAsync();

            return operarios;
        }
        [HttpPost]

        public async Task<ActionResult> Post(OperarioCreacionDTO operarioCreacionDTO)
        {
            var yaexiste = await context.operario.AnyAsync(x => x.Nombre == operarioCreacionDTO.Nombre);

            if (yaexiste)
            {
                return BadRequest($"Ya existe el nombre {operarioCreacionDTO.Nombre}");
            }

            var operario = mapper.Map<Operario>(operarioCreacionDTO);

            context.Add(operario);
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

            var yaexiste = await context.operario.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return NotFound($"No existe el Operario con el id {operario.Id}");
            }

            
            context.Update(operario);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var yaexiste = await context.operario.AnyAsync(x => x.Id == id);

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
