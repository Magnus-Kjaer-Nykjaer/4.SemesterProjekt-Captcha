namespace Captcha.Shared
{
  public class Route
  {
    public const string Api = "/Api/";
    public const string GetASelectedCaptcha = Api + "GetASelectedCaptcha";
    public const string UpdateCaptchaName = Api + "UpdateCaptchaName";
    public const string PostCaptcha = Api + "PostCaptcha";

    public const string MLImageCompare_Api = "/MLImageCompare_Api/";
    public const string Predict = MLImageCompare_Api + "Predict";
  }
}
