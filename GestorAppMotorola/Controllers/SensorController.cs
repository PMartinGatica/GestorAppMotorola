using GestorAppMotorola.Modelos;
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
    public class SensorController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public SensorController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sensor>>> Get()
        {
            return await context.Sensor.ToListAsync();
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Sensor>> Get(int id)
        {
           var sensorOK = await context.Sensor.FirstOrDefaultAsync(x => x.Id == id);
           if (sensorOK == null)
            {
                return NotFound();
            }
            return sensorOK;
        }

        [HttpPost]
        public async Task<ActionResult> Post
    }
}
