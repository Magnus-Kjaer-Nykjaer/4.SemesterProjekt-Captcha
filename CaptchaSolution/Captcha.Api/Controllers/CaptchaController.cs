using System.Threading.Tasks;
using Captcha.Api.Repositories;
using Captcha.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.Api.Controllers
{
    [ApiController]
    public class CaptchaController : Controller
    {
        private readonly CaptchaRepository _captchaRepository;

        public CaptchaController(CaptchaRepository captchaRepository)
        {
            _captchaRepository = captchaRepository;
        }

        [HttpGet/*(Route.GetASelectedCaptcha)*/]
        public async Task GetASelectedCaptcha(string captchaName)
        {
            await _captchaRepository.GetASelectedCaptcha(captchaName);
        }
        
        [HttpPut/*(Route.UpdateCaptchaName)*/]
        public async Task UpdateCaptchaName(string captchaName, string change)
        {
            await _captchaRepository.UpdateCaptchaName(captchaName, change);
        }    
        
        [HttpPost/*(Route.PostCaptcha)*/]
        public async Task PostCaptcha(string captchaName)
        {
            await _captchaRepository.PostCaptcha(captchaName);
        }
    }
}
