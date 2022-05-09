using System.Threading.Tasks;

namespace Captcha.MVC.Service
{
  public class CaptchaService
  {

    public async Task GetASelectedCaptcha(string captchaName)
    {
      await _captchaRepository.GetASelectedCaptcha(captchaName);
    }

    public async Task UpdateCaptchaName(string captchaName, string change)
    {
      await _captchaRepository.UpdateCaptchaName(captchaName, change);
    }

    public async Task PostCaptcha(string captchaName)
    {
      await _captchaRepository.PostCaptcha(captchaName);
    }
  }
}
