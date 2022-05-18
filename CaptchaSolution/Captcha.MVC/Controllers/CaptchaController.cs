using System;
using System.Net.Http;
using Captcha.MVC.Service;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System.Threading.Tasks;

namespace Captcha.MVC.Controllers
{
  [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Standard, Admin")]
  public class CaptchaController : Controller
  {
    private readonly ILogger<CaptchaController> _logger;
    private readonly IAIService _aiService;
    private readonly ICaptchaService _captchaService;

    public CaptchaController(IAIService aiService, ILogger<CaptchaController> logger, ICaptchaService captchaService)
    {
      _aiService = aiService;
      _logger = logger;
      _captchaService = captchaService;
    }

    public ActionResult CaptchaGuessr()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> CaptchaGuessr([FromForm] ModelInputDTO label)
    {
      try
      {
        var result = await _aiService.PredictImage("Guess", new StreamPart(label.File.OpenReadStream(), label.File.FileName));

        await _captchaService.PostCaptchaResult(result);

        result.Score *= 100;
        return View("CaptchaGuessrResult", result);
      }
      catch (Exception e)
      {
        _logger.LogError("{e}", e);
      }
      return RedirectToAction("Index", "Home");
    }

  }
}
