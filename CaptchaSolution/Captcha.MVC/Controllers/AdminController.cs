using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AdminController : Controller
  {
    public IActionResult AdminPanel()
    {
      return View();
    }

  }
}
