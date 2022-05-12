namespace Captcha.Shared
{
  public class CaptchaModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] FileBytes { get; set; }
  }
}