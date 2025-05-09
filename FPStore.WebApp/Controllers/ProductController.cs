using Microsoft.AspNetCore.Mvc;

namespace FPStore.WebApp.Controllers
{
  public class ProductController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Get()
    {
      return View();
    }
  }
}