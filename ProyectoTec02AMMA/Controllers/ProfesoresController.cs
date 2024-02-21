using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoTec02AMMA.Models;

namespace ProyectoTec02AMMA.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly UniversidadContext _context;

        public ProfesoresController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            var universidadContext = _context.Profesores.Include(p => p.Carrera);
            return View(await universidadContext.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Nombre");
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesorId,Nombre,Apellido,Foto,CarreraId")] Profesore profesore, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null && Foto.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Foto.CopyToAsync(memoryStream);
                        profesore.Foto = memoryStream.ToArray();
                    }
                }
                _context.Add(profesore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Nombre", profesore.CarreraId);
            return View(profesore);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Nombre", profesore.CarreraId);
            return View(profesore);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesorId,Nombre,Apellido,Foto,CarreraId")] Profesore profesore, IFormFile Foto)
        {
            if (id != profesore.ProfesorId)
            {
                return NotFound();
            }
            if (Foto != null && Foto.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Foto.CopyToAsync(memoryStream);
                    profesore.Foto = memoryStream.ToArray();
                }
                _context.Update(profesore);
                await _context.SaveChangesAsync();
            }
            else
            {
                var producFind = await _context.Profesores.FirstOrDefaultAsync(s => s.ProfesorId == profesore.ProfesorId);
                if (producFind?.Foto?.Length > 0)
                    profesore.Foto = producFind.Foto;
                producFind.Nombre = profesore.Nombre;
                producFind.Apellido = profesore.Apellido;
                producFind.CarreraId = profesore.CarreraId;
                _context.Update(producFind);
                await _context.SaveChangesAsync();
            }


            try
            {
                    _context.Update(profesore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesoreExists(profesore.ProfesorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            /*ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId", profesore.CarreraId);
            return View(profesore);*/
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore != null)
            {
                _context.Profesores.Remove(profesore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoreExists(int id)
        {
            return _context.Profesores.Any(e => e.ProfesorId == id);
        }
    }
}
