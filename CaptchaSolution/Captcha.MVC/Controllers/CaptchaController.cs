using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Controllers
{
  [Authorize(Roles = "Standard, Admin")]
  public class CaptchaController : Controller
  {
    public IActionResult CaptchaLabeler()
    {
      return View();
    }
  }
}
