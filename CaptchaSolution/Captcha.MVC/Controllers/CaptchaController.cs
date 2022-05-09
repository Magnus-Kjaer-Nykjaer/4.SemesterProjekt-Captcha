using Captcha.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

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
