using Captcha.MVC.Models;
using Captcha.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AdminController : Controller
  {
    public IActionResult Index()
    {
      return View();
    } 

    public IActionResult CreateLabel(CaptchaLabelDto label)
    {

      return View();
    }

  }
}
