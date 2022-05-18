using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.Shared
{
  public class CaptchaModelResult
  {
    public string Id { get; set; }
    public uint Label { get; set; }
    public string PredictedLabel { get; set; }
    public decimal Score { get; set; }
  }
}
