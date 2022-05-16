using Captcha.Shared;
using System.Threading.Tasks;

namespace Captcha.Api.Repositories
{
  public interface ICaptchaRepository
  {
    Task<CaptchaLabelDto> GetASelectedCaptcha(string captchaName);
    Task UpdateCaptchaName(string captchaName, string change);
    Task PostCaptcha(CaptchaLabelDto captchaLabel);
  }
}
