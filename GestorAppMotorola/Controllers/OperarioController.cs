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
        public async Task<ActionResult<IEnumerable<OperarioGetDTO>>> GetOperario()
        {
            var oper = await context.Operario.ToListAsync();
            return mapper.Map<List<OperarioGetDTO>>(oper);
        }

       

        [HttpGet("{id}")]
        public async Task<ActionResult<OperarioDTOConInstalaciones>> GetOperario(int id)
        {
            var operario = await context.Operario
                .Include(dboperario=>dboperario.Instalaciones).FirstOrDefaultAsync(x => x.OperarioId == id);


            if (operario == null)
            {
                return NotFound();
            }

            return mapper.Map<OperarioDTOConInstalaciones>(operario);
        }


        [HttpPost]

        public async Task<ActionResult<Operario>> PostOperario(OperarioCreacionDTO operarioCreacionDTO)
        {
            
            var operario = mapper.Map<Operario>(operarioCreacionDTO);

            context.Operario.Add(operario);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetOperario", new { id = operario.OperarioId }, operario);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutOperacion(Operario operario, int id)
        {
            if (operario.OperarioId != id)
            {
                return BadRequest("El id del Operario no coincide con el id de la URL");
            }

            context.Entry(operario).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!OperarioExiste(id))
                {
                    return NotFound($"No existe el Operario con el id {operario.OperarioId}");
                }

                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteOperario(int id)
        {
            var operario = await context.Operario.FindAsync(id);

            if (operario == null)
            {
                return NotFound();
            }

            context.Operario.Remove(operario);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool OperarioExiste(int id)
        {
            return context.Operario.Any(x => x.OperarioId == id);
        }

    }
}
