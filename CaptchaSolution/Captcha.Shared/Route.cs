using System;

namespace Captcha.Shared
{
  public class Route
  {
        public static string Api = "api/";
        public string GetASelectedCaptcha = Api + "GetASelectedCaptcha";
        public string UpdateCaptchaName = Api + "UpdateCaptchaName";
        public string PostCaptcha = Api + "PostCaptcha";
  }
}
