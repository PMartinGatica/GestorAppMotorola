using AutoMapper;
using GestorAppMotorola.DTOs;
using GestorAppMotorola.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<AppGetDTO>>> GetApp()
        {
            var app = await context.App.ToListAsync();
            return mapper.Map<List<AppGetDTO>>(app);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppGetDTO>> GetApp(int id)
        {
            var app = await context.App.FindAsync(id);


            if (app == null)
            {
                return NotFound();
            }

            return mapper.Map<AppGetDTO>(app);
        }

        [HttpPost]

        public async Task<ActionResult<App>> PostApp(AppCreacionDTO appCreacionDTO)
        {

            var app = mapper.Map<App>(appCreacionDTO);

            context.App.Add(app);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetApp", new { id = app.Id }, app);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutApp(App app, int id)
        {
            if (app.Id != id)
            {
                return BadRequest("El id de la App no coincide con el id de la URL");
            }

            context.Entry(app).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!AppExiste(id))
                {
                    return NotFound(/*$"No existe la APP con el id {app.Id}"*/);
                }

                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteAPP(int id)
        {
            var app = await context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound();
            }

            context.App.Remove(app);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool AppExiste(int id)
        {
            return context.App.Any(x => x.Id == id);
        }

    }
}
