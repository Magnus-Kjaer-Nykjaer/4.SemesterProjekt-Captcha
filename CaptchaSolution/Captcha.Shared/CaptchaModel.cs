namespace Captcha.Shared
{
  public class CaptchaModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public byte[] FileBytes { get; set; }
  }
}