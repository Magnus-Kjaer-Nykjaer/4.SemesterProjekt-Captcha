using System.Threading.Tasks;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Service
{
  public class CaptchaService : ICaptchaService
  {
    public async Task<CaptchaModel> GetASelectedCaptcha(string captchaName)
    {
      return await GetASelectedCaptcha(captchaName);
    }

    public async Task<IActionResult> UpdateCaptchaName(string captchaName, string change)
    {
      return await UpdateCaptchaName(captchaName, change);
    }

    public async Task<IActionResult> PostCaptcha(string captchaName, byte[] fileBytes)
    {
      return await PostCaptcha(captchaName, fileBytes);
    }
  }
}
