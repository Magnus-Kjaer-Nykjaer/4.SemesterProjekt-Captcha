using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Captcha.Shared
{
  public class ModelInputDTO
  {
    [Required]
    [Display(Name = "FileName")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "File")]
    public IFormFile File { get; set; }
  }
}
