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

    public CaptchaController(IAIService aiService, ILogger<CaptchaController> logger)
    {
      _aiService = aiService;
      _logger = logger;
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
        var result = await _aiService.PredictImage(label.Name, new StreamPart(label.File.OpenReadStream(), label.File.FileName));


        result.Score *= 100;
        return View("CaptchaGuessrResult", result);
      }
      catch (HttpRequestException e)
      {
        _logger.LogError("{e}", e);
      }
      return RedirectToAction("Index", "Home");
    }

  }
}
