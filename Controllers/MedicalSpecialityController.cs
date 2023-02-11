using Microsoft.AspNetCore.Mvc;

namespace shifts.Controllers;

public class MedicalSpecialityController : Controller
{
  public MedicalSpecialityController()
  {
  }
  
  public IActionResult Index()
  {
    return View();
  }
}