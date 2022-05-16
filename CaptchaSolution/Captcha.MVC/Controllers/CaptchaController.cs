using Captcha.MVC.Service;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Refit;
using static System.Net.Mime.MediaTypeNames;

namespace Captcha.MVC.Controllers
{
  [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Standard, Admin")]
  public class CaptchaController : Controller
  {
    private readonly IAIService _aiService;

    public CaptchaController(IAIService aiService)
    {
      _aiService = aiService;
    }

    public async Task<IActionResult> CaptchaGuessr()
    {
      await test();

      return View();
    }
    public async Task test ()
    {
      var dtoInput = new ModelInputDTO();
      // System.IO.File.OpenRead("");

      // dtoInput.ImageSource = new FormFile(memoryStream, 0, memoryStream.Length, "test", "test");
      dtoInput.Label = "test";

      var test = await _aiService.PredictImage(new StreamPart(memoryStream, "test.jpg", "image/jpeg"));
    }
  }
}
