using System.Threading.Tasks;

namespace Captcha.MVC.Service
{
  public class CaptchaService
  {
    public readonly ICaptchaApi _captchaApi;

    public CaptchaService(ICaptchaApi captchaApi)
    {
      _captchaApi = captchaApi;
    }

    public async Task GetASelectedCaptcha(string captchaName)
    {
      await _captchaApi.GetASelectedCaptcha(captchaName);
    }

    public async Task UpdateCaptchaName(string captchaName, string change)
    {
      await _captchaApi.UpdateCaptchaName(captchaName, change);
    }

    public async Task PostCaptcha(string captchaName)
    {
      await _captchaApi.PostCaptcha(captchaName);
    }
  }
}
