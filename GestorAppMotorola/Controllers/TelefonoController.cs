using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorAppMotorola;
using GestorAppMotorola.Modelos;
using AutoMapper;
using GestorAppMotorola.DTOs;

namespace GestorAppMotorola.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class TelefonoController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public TelefonoController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]

        // GET: Telefonoes
        public async Task<ActionResult<IEnumerable<TelefonoGetDTO>>> Gettelefono()
        {
            var tel = await context.Telefono.ToListAsync();
            return mapper.Map<List<TelefonoGetDTO>>(tel);
        }

        // GET: Telefonoes/Details/5

        [HttpGet("{id}")]
        public async Task<ActionResult<OperarioGetDTO>> Gettelefono(int id)
        {
            var tel = await context.Telefono.FindAsync(id);
            if (tel == null)
            {
                return NotFound();
            }

            return mapper.Map<TelefonoGetDTO>(tel);
        }

        // GET: Telefonoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telefonoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Precio")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        // GET: Telefonoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        // POST: Telefonoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Precio")] Telefono telefono)
        {
            if (id != telefono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        // GET: Telefonoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefono = await _context.Telefono.FindAsync(id);
            _context.Telefono.Remove(telefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
            return _context.Telefono.Any(e => e.Id == id);
        }
    }
}
