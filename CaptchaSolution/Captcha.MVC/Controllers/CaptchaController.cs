using Captcha.MVC.Service;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Refit;
using static System.Net.Mime.MediaTypeNames;

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

        return View("CaptchaGuessrResult", result);
      }
      catch (ApiException e)
      {
        _logger.LogError("{e}", e);
      }
      return RedirectToAction("Index", "Home");
    }

  }
}
