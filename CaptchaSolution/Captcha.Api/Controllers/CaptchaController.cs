using Captcha.Api.Repositories;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Captcha.Api.Controllers
{
  [ApiController]
  public class CaptchaController : Controller
  {
    private readonly ICaptchaRepository _captchaRepository;

    public CaptchaController(ICaptchaRepository captchaRepository)
    {
      _captchaRepository = captchaRepository;
    }

    [HttpGet(Route.GetASelectedCaptcha)]
    public async Task<CaptchaModel> GetASelectedCaptcha(string captchaName)
    {
      return await _captchaRepository.GetASelectedCaptcha(captchaName);
    }

    [HttpPut(Route.UpdateCaptchaName)]
    public async Task<IActionResult> UpdateCaptchaName(string captchaName, string change)
    {
      await _captchaRepository.UpdateCaptchaName(captchaName, change);
      return Ok();
    }

    [HttpPost(Route.PostCaptcha)]
    public async Task<IActionResult> PostCaptcha(string captchaName, byte[] fileBytes)
    {
      await _captchaRepository.PostCaptcha(captchaName, fileBytes);
      return Ok();
    }
  }
}
