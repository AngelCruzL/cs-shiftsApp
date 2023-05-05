using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shifts.Models;

namespace shifts.Controllers;

public class PatientController : Controller
{
  private readonly ShiftsContext _context;

  public PatientController(ShiftsContext context)
  {
    _context = context;
  }

  public async Task<IActionResult> Index()
  {
    return View(await _context.Patients.ToListAsync());
  }

  public async Task<IActionResult> Details(int? id)
  {
    if (id == null) return NotFound();

    var patient = await _context.Patients
      .FirstOrDefaultAsync(p => p.Id == id);

    if (patient == null) return NotFound();

    return View(patient);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(
    [Bind("Id,Name,LastName,Address,PhoneNumber,Email")]
    Patient patient
  )
  {
    if (!ModelState.IsValid) return View(patient);

    _context.Add(patient);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }
}