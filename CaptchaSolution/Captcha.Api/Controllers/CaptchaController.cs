using Captcha.Api.Repositories;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Captcha.Api.Controllers
{
  [ApiController]
  public class CaptchaController : ControllerBase
  {
    private readonly ICaptchaRepository _captchaRepository;

    public CaptchaController(ICaptchaRepository captchaRepository)
    {
      _captchaRepository = captchaRepository;
    }

    [HttpGet(Route.GetASelectedCaptcha)]
    public async Task<CaptchaLabelDto> GetASelectedCaptcha(string captchaName)
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
    public async Task PostCaptcha([FromForm] CaptchaLabelDto captchaLabel) => 
      await _captchaRepository.PostCaptcha(captchaLabel); 
    
    [HttpPost(Route.PostCaptchaResult)]
    public async Task PostCaptchaResult([FromBody] ModelOutputDTO captchaResult) => 
      await _captchaRepository.PostCaptchaResult(captchaResult);
  }
}
