using System.Threading.Tasks;
using Captcha.MVC.Models;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Service
{
  public class CaptchaService : ICaptchaService
  {
    public async Task<CaptchaModel> GetASelectedCaptcha(string captchaName)
    {
      return null;
    }

    public async Task<IActionResult> UpdateCaptchaName(string captchaName, string change)
    {
      return null;
    }

    public async Task<IActionResult> PostCaptcha(CaptchaLabelDto captchaLabel)
    {
      return null;
    }
  }
}
