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

        public InstalacionController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstalacionGetDTO>>> GetInstalacion()
        {

            var instalacion = await context.Instalacion
                .Include(x => x.Operario)
                .Include(x => x.App)
                .Include(x => x.Telefono).ToListAsync();

            return mapper.Map<List<InstalacionGetDTO>>(instalacion);
        }

        //[HttpGet("instalacionOK")]
        //public dynamic instalacionOK(Boolean exitosa)
        //{
        //    return context.Instalacion
        //        .Where(item =>
        //            item.Exitosa == true )
        //        .Select(item => new {
        //            item.Exitosa,
        //            aplicacion = item.App.Nombre
        //        })
        //        .ToList();
        //}

        

        [HttpGet("{id}")]
        public async Task<ActionResult<InstalacionesDTOConTelefonos>> GetInstalacion(int id)
        {
           var instalar = await context.Instalacion
                .Include(x=>x.Operario)
                .Include(x=>x.App)
                .Include(x => x.Telefono)
                .FirstOrDefaultAsync(x=>x.InstalacionId == id);

           if (instalar == null)
           {
               return NotFound();
          }

            return mapper.Map<InstalacionesDTOConTelefonos>(instalar);
        }

        [HttpPost]

        public async Task<ActionResult<Instalacion>> PostInstalacion(InstalacionCreacionDTO instalacionCreacionDTO)
        {            


            var instalar = mapper.Map<Instalacion>(instalacionCreacionDTO);
            context.Instalacion.Add(instalar);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetInstalacion", new {id=instalar.InstalacionId },instalar);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutInstalar(Instalacion Instalacion, int id)
        {
            if (Instalacion.InstalacionId != id)
            {
                return BadRequest("El id de la instalacion no coincide con el id de la URL");
            }

            context.Entry(Instalacion).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstalacionExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            
                
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteInstalacion(int id)
        {
            var instalar = await context.Instalacion.FindAsync(id);

            if (instalar==null)
            {
                return NotFound();
            }

            context.Instalacion.Remove(instalar);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool InstalacionExiste(int id)
        {
            return context.Instalacion.Any(e => e.InstalacionId == id);
        }


    }
}
