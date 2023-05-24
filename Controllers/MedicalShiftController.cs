using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shifts.Models;

namespace shifts.Controllers;

public class MedicalShiftController : Controller
{
  private readonly IConfiguration _configuration;
  private readonly ShiftsContext _shiftsContext;

  public MedicalShiftController(ShiftsContext shiftsContext, IConfiguration configuration)
  {
    _shiftsContext = shiftsContext;
    _configuration = configuration;
  }

  public IActionResult Index()
  {
    ViewData["IdMedic"] = new SelectList(
      from medic in _shiftsContext.Medic.ToList()
      select new { id = medic.Id, fullName = $"{medic.Name} {medic.LastName}" },
      "id", "fullName"
    );
    ViewData["IdPatient"] = new SelectList(
      from patient in _shiftsContext.Patients.ToList()
      select new { id = patient.Id, fullName = $"{patient.Name} {patient.LastName}" },
      "id", "fullName"
    );
    return View();
  }
}