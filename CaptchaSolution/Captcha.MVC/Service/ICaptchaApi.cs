using System.Threading.Tasks;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Captcha.MVC.Service
{
  public interface ICaptchaApi
  {
    [Get(Route.GetASelectedCaptcha)]
    Task<CaptchaModel> GetASelectedCaptcha(string captchaName);

    [Put(Route.UpdateCaptchaName)]
    Task<IActionResult> UpdateCaptchaName(string captchaName, string change);

    [Post(Route.PostCaptcha)]
    Task<IActionResult> PostCaptcha(string captchaName);
  }
}