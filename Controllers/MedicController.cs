using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shifts.Models;

namespace shifts.Controllers;

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
    return _context.Medic != null
      ? View(await _context.Medic.ToListAsync())
      : Problem("Entity set 'ShiftsContext.Medic'  is null.");
  }

  // GET: Medic/Details/5
  public async Task<IActionResult> Details(int? id)
  {
    if (id == null || _context.Medic == null) return NotFound();

    var medic = await _context.Medic
      .Where(m => m.Id == id).Include(mme => mme.MedicMedicalSpecialities!)
      .ThenInclude(me => me.MedicalSpeciality).FirstOrDefaultAsync();

    if (medic == null) return NotFound();

    return View(medic);
  }

  // GET: Medic/Create
  public IActionResult Create()
  {
    ViewData["MedicalSpecialities"] = new SelectList(
      _context.MedicalSpecialities,
      "Id",
      "Description"
    );

    return View();
  }

  // POST: Medic/Create
  // To protect from overposting attacks, enable the specific properties you want to bind to.
  // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(
    [Bind("Id,Name,LastName,Address,PhoneNumber,Email,ScheduleFrom,ScheduleUntil")]
    Medic medic,
    int idMedicalSpeciality)
  {
    if (!ModelState.IsValid) return View(medic);

    _context.Add(medic);
    await _context.SaveChangesAsync();

    var medicMedicalSpeciality = new MedicMedicalSpeciality
    {
      IdMedic = medic.Id,
      IdMedicalSpeciality = idMedicalSpeciality
    };

    _context.Add(medicMedicalSpeciality);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }

  // GET: Medic/Edit/5
  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null || _context.Medic == null) return NotFound();

    var medic = await _context.Medic.Where(medic => medic.Id == id)
      .Include(mme => mme.MedicMedicalSpecialities)
      .FirstOrDefaultAsync();
    if (medic == null) return NotFound();

    ViewData["MedicalSpecialities"] = new SelectList(
      _context.MedicalSpecialities,
      "Id",
      "Description",
      medic.MedicMedicalSpecialities![0].IdMedicalSpeciality
    );

    return View(medic);
  }

  // POST: Medic/Edit/5
  // To protect from overposting attacks, enable the specific properties you want to bind to.
  // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int id,
    [Bind("Id,Name,LastName,Address,PhoneNumber,Email,ScheduleFrom,ScheduleUntil")]
    Medic medic,
    int idMedicalSpeciality)
  {
    if (id != medic.Id) return NotFound();

    if (!ModelState.IsValid) return View(medic);

    try
    {
      _context.Update(medic);
      await _context.SaveChangesAsync();

      var medicMedicalSpeciality = await _context.MedicMedicalSpeciality
        .FirstOrDefaultAsync(mms => mms.IdMedic == medic.Id);

      _context.Remove(medicMedicalSpeciality!);
      await _context.SaveChangesAsync();

      medicMedicalSpeciality!.IdMedicalSpeciality = idMedicalSpeciality;

      _context.Add(medicMedicalSpeciality);
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!MedicExists(medic.Id))
        return NotFound();
      throw;
    }

    return RedirectToAction(nameof(Index));
  }

  // GET: Medic/Delete/5
  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null || _context.Medic == null) return NotFound();

    var medic = await _context.Medic
      .FirstOrDefaultAsync(m => m.Id == id);
    if (medic == null) return NotFound();

    return View(medic);
  }

  // POST: Medic/Delete/5
  [HttpPost]
  [ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    if (_context.Medic == null) return Problem("Entity set 'ShiftsContext.Medic'  is null.");

    var medicMedicalSpeciality = await _context.MedicMedicalSpeciality
      .FirstOrDefaultAsync(mms => mms.IdMedic == id);
    _context.MedicMedicalSpeciality.Remove(medicMedicalSpeciality!);
    await _context.SaveChangesAsync();

    var medic = await _context.Medic.FindAsync(id);
    if (medic != null) _context.Medic.Remove(medic);

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }

  private bool MedicExists(int id)
  {
    return (_context.Medic?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}