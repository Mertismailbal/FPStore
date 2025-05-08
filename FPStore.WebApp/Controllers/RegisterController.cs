using Microsoft.AspNetCore.Mvc;

namespace FPStore.WebApp.Controllers
{
  public class RegisterController : Controller
  {
    public IActionResult Login()
    {
      return View();
    }

    public IActionResult Signup()
    {
      return View();
    }
  }
}