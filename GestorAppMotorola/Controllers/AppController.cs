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
            var app = await context.App
                .ToListAsync();

            return mapper.Map<List<AppGetDTO>>(app);
        }

        [HttpGet("exitosas")]
        public async Task<ActionResult<IEnumerable<AppDTOConInstalaciones>>> GetExitosas()
        {
            var app = await context.App
                .Include(x => x.Instalaciones)
                .ToListAsync();

            return mapper.Map<List<AppDTOConInstalaciones>>(app);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppGetDTO>> GetAppID(int id)
        {
            var app = await context.App
            .FirstOrDefaultAsync(x=>x.AppId==id);


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
            return CreatedAtAction("GetApp", new { id = app.AppId }, app);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutApp(App app, int id)
        {
            if (app.AppId != id)
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
            return context.App.Any(x => x.AppId == id);
        }

    }
}
