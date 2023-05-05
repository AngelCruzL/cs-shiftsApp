using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shifts.Models;

namespace shifts.Controllers
{
    public class MedicController : Controller
    {
        private readonly ShiftsContext _context;

        public MedicController(ShiftsContext context)
        {
            _context = context;
        }

        // GET: Medic
        public async Task<IActionResult> Index()
        {
              return _context.Medic != null ? 
                          View(await _context.Medic.ToListAsync()) :
                          Problem("Entity set 'ShiftsContext.Medic'  is null.");
        }

        // GET: Medic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medic == null)
            {
                return NotFound();
            }

            var medic = await _context.Medic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
        }

        // GET: Medic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Address,PhoneNumber,Email,ScheduleFrom,ScheduleUntil")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medic);
        }

        // GET: Medic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medic == null)
            {
                return NotFound();
            }

            var medic = await _context.Medic.FindAsync(id);
            if (medic == null)
            {
                return NotFound();
            }
            return View(medic);
        }

        // POST: Medic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Address,PhoneNumber,Email,ScheduleFrom,ScheduleUntil")] Medic medic)
        {
            if (id != medic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicExists(medic.Id))
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
            return View(medic);
        }

        // GET: Medic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medic == null)
            {
                return NotFound();
            }

            var medic = await _context.Medic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
        }

        // POST: Medic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medic == null)
            {
                return Problem("Entity set 'ShiftsContext.Medic'  is null.");
            }
            var medic = await _context.Medic.FindAsync(id);
            if (medic != null)
            {
                _context.Medic.Remove(medic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicExists(int id)
        {
          return (_context.Medic?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
