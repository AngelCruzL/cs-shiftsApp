using Microsoft.AspNetCore.Mvc;
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
}