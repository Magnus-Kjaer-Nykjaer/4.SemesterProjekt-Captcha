using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Controllers
{
  [Authorize(Roles = "Admin, Standard")]
  public class CaptchaController : Controller
  {
    [Authorize(Roles = "Admin")]
    public IActionResult CaptchaLabeler()
    {
      return View();
    }
  }
}
