using Captcha.Shared;
using System.Threading.Tasks;

namespace Captcha.Api.Repositories
{
  public interface ICaptchaRepository
  {
    
    public Task<CaptchaModel> GetASelectedCaptcha(string captchaName);
    public Task UpdateCaptchaName(string captchaName, string change);
    public Task PostCaptcha(string captchaName);
  }
}
