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

  public JsonResult GetMedicalShifts(int idMedic)
  {
    var medicalShifts = new List<MedicalShift>();
    medicalShifts = _shiftsContext.MedicalShift.Where(ms => ms.IdMedic == idMedic).ToList();

    return Json(medicalShifts);
  }

  [HttpPost]
  public JsonResult CreateMedicalShift(MedicalShift medicalShift)
  {
    var ok = false;

    try
    {
      _shiftsContext.MedicalShift.Add(medicalShift);
      _shiftsContext.SaveChanges();
      ok = true;
    }
    catch (Exception e)
    {
      Console.WriteLine($"Exception found: {e}");
      throw;
    }

    var jsonResult = new JsonResult(new { ok });
    return jsonResult;
  }

  [HttpPost]
  public JsonResult DeleteMedicalShift(int id)
  {
    var ok = false;

    try
    {
      var medicalShift = _shiftsContext.MedicalShift.Find(id);
      if (medicalShift != null) _shiftsContext.MedicalShift.Remove(medicalShift);
      _shiftsContext.SaveChanges();
      ok = true;
    }
    catch (Exception e)
    {
      Console.WriteLine($"Exception found: {e}");
      throw;
    }

    var jsonResult = new JsonResult(new { ok });
    return jsonResult;
  }
}