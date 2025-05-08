using Microsoft.AspNetCore.Mvc;

namespace FPStore.WebApp.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}