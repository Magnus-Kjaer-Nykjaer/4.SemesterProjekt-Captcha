using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Captcha.Shared
{
  public class ModelOutputDTO
  {
    [Required]
    [Display(Name = "Label")]
    public uint Label { get; set; }

    [Required]
    [Display(Name = "PredictedLabel")]
    public string PredictedLabel { get; set; }

    [Required]
    [Display(Name = "Score")]
    public float[] Score { get; set; }
  }
}
