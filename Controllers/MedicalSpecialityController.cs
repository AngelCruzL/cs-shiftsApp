using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shifts.Models;

namespace shifts.Controllers;

public class MedicalSpecialityController : Controller
{
  private readonly ShiftsContext _context;

  public MedicalSpecialityController(ShiftsContext context)
  {
    _context = context;
  }

  public async Task<IActionResult> Index()
  {
    return View(await _context.MedicalSpecialities.ToListAsync());
  }

  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null) return NotFound();

    var medicalSpeciality = await _context.MedicalSpecialities.FindAsync(id);
    if (medicalSpeciality == null) return NotFound();

    return View(medicalSpeciality);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, [Bind("Id, Description")] MedicalSpeciality medicalSpeciality)
  {
    if (id != medicalSpeciality.Id) return NotFound();

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(medicalSpeciality);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        throw new Exception($"MedicalSpeciality {id} not found!");
      }

      return RedirectToAction(nameof(Index));
    }

    return View(medicalSpeciality);
  }

  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null) return NotFound();

    var medicalSpeciality = await _context.MedicalSpecialities.FirstOrDefaultAsync(s => s.Id == id);
    if (medicalSpeciality == null) return NotFound();

    return View(medicalSpeciality);
  }

  [HttpPost, ActionName("Delete")]
  public async Task<IActionResult> Delete(int id)
  {
    var medicalSpeciality = await _context.MedicalSpecialities.FindAsync(id);
    _context.MedicalSpecialities.Remove(medicalSpeciality);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }
}