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

  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null) return NotFound();

    var patient = await _context.Patients.FindAsync(id);

    if (patient == null) return NotFound();

    return View(patient);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(
    int id,
    [Bind("Id,Name,LastName,Address,PhoneNumber,Email")]
    Patient patient
  )
  {
    if (id != patient.Id) return NotFound();

    if (!ModelState.IsValid) return View(patient);

    try
    {
      _context.Update(patient);
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!PatientExists(patient.Id)) return NotFound();
      throw;
    }

    return RedirectToAction(nameof(Index));
  }

  private bool PatientExists(int patientId)
  {
    return _context.Patients.Any(p => p.Id == patientId);
  }
}