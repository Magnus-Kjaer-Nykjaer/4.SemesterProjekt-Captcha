using System;
using System.Threading.Tasks;
using Captcha.MVC.Service;
using Captcha.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Captcha.MVC.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AdminController : Controller
  {
    private readonly ILogger<AdminController> _logger;
    private readonly ICaptchaService _captchaService;

    public AdminController(ICaptchaService captchaService, ILogger<AdminController> logger)
    {
      _captchaService = captchaService;
      _logger = logger;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(CaptchaLabelDto label)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _captchaService.PostCaptcha(label);
          return RedirectToAction(nameof(Index));
        }
      }
      catch
      {
        _logger.LogError("Der gik et eller andet galt under oprettelsen");
      }
      return RedirectToAction(nameof(Index));
    }
  }
}
