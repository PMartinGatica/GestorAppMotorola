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

        public AppController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<App>>> Get()
        {
            return await context.App.ToListAsync();
        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<App>> Get(int id)
        {
            var app = await context.App.FirstOrDefaultAsync(x => x.Id == id);
            if (app == null)
            {
                return NotFound($"No existe una App con la id {app.Id}");
            }

            return app;
        }

        [HttpPost]

        public async Task<ActionResult> Post(App App)
        {
            var yaexiste = await context.App.AnyAsync(x => x.Nombre == App.Nombre);

            if (yaexiste)
            {
                return BadRequest($"Ya existe una aplicacion con el nombre {App.Nombre}");
            }

            context.Add(App);
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

        [HttpDelete("{id=int}")]

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
