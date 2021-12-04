using AutoMapper;
using GestorAppMotorola.DTOs;
using GestorAppMotorola.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorAppMotorola.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class AppController : ControllerBase

    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public AppController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<AppGetDTO>>> Get()
        {
            var ap = await context.operario.ToListAsync();
            return mapper.Map<List<AppGetDTO>>(ap);
        }


        [HttpGet("{Id}")]

        public async Task<ActionResult<AppGetDTO>> Get(int id)
        {
            var app = await context.App.Include(x => x.Instalacion).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<AppGetDTO>(app);
        }

        [HttpPost]

        public async Task<ActionResult> Post(AppCreacionDTO appCreacionDTO)
        {
            var yaexiste = await context.App.AnyAsync(x => x.Nombre == appCreacionDTO.Nombre);

            if (yaexiste)
            {
                return BadRequest($"Ya existe una aplicacion con el nombre {appCreacionDTO.Nombre}");
            }

            var ap = mapper.Map<App>(appCreacionDTO);
            context.Add(ap);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(App App, int id)
        {
            if (App.Id != id)
            {
                return BadRequest("El id de la APP no coincide con el id de la URL");
            }

            var yaexiste = await context.App.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return NotFound($"No existe el APP con el id {App.Id}");
            }

            //context.Entry(App).State = EntityState.Modified;
            context.Update(App);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var yaexiste = await context.App.AnyAsync(x => x.Id == id);

            if (!yaexiste)
            {
                return BadRequest();
            }

            context.Remove(new App() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
