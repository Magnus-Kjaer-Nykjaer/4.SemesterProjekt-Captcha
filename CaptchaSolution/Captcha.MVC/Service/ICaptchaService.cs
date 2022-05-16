using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace Captcha.MVC.Service
{
  public interface ICaptchaService
  {
    [Get(Route.GetASelectedCaptcha)]
    Task<CaptchaModel> GetASelectedCaptcha(string captchaName);

    [Put(Route.UpdateCaptchaName)]
    Task<IActionResult> UpdateCaptchaName(string captchaName, string change);

    [Multipart]
    [Post(Route.PostCaptcha)]
    Task PostCaptcha(string name, [AliasAs(nameof(CaptchaLabelDto.File))] StreamPart file);
  }
}