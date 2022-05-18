using Refit;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Captcha.Shared
{
  public class CaptchaLabelDto
  {
    [Required]
    public uint Label { get; set; }

    [Required]
    public string PredictedLabel { get; set; }

    [Required]
    public float Score { get; set; }
  }
}