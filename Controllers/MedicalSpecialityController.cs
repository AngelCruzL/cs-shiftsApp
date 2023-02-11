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

  public IActionResult Index()
  {
    return View(_context.MedicalSpecialities.ToList());
  }

  public IActionResult Edit(int? id)
  {
    if (id == null) return NotFound();

    var medicalSpeciality = _context.MedicalSpecialities.Find(id);
    if (medicalSpeciality == null) return NotFound();

    return View(medicalSpeciality);
  }

  [HttpPost]
  public IActionResult Edit(int id, [Bind("Id, Description")] MedicalSpeciality medicalSpeciality)
  {
    if (id != medicalSpeciality.Id) return NotFound();

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(medicalSpeciality);
        _context.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        throw new Exception($"MedicalSpeciality {id} not found!");
      }

      return RedirectToAction(nameof(Index));
    }

    return View(medicalSpeciality);
  }
}