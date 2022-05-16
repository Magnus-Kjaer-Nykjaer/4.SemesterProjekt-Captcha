using Captcha.MVC.Service;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System.Threading.Tasks;

namespace Captcha.MVC.Controllers
{
  [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
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
    public async Task<ActionResult> Create([FromForm] CaptchaLabelDto label)
    {
      try
      {
        await _captchaService.PostCaptcha(label.Name, new StreamPart(label.File.OpenReadStream(), label.File.FileName));

        return RedirectToAction("Index", "Home");
      }
      catch (ApiException e)
      {
        _logger.LogError("{e}", e);
      }
      return RedirectToAction("Index", "Home");
    }
  }
}
