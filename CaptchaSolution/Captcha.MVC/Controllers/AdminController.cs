using System;
using Captcha.MVC.Service;
using Captcha.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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

    public ActionResult Create()
    {
      return View();
    }


    [HttpPost]
    public async Task<ActionResult> Create(CaptchaLabelDto label)
    {
      try
      {
        await _captchaService.PostCaptcha(label);

        return RedirectToAction("Index" , "Home");
      }
      catch(Exception e)
      {
        _logger.LogError("{e}", e);
      }
      return RedirectToAction("Index", "Home");
    }
  }
}
