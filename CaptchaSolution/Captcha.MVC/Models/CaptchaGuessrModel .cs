using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace Captcha.MVC.Models
{
  public class CaptchaGuessrModel : PageModel
  {
    private IWebHostEnvironment _environment;
    public CaptchaGuessrModel(IWebHostEnvironment environment)
    {
      _environment = environment;
    }
    [BindProperty]
    public IFormFile Upload { get; set; }
    public async Task OnPostAsync()
    {
      var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
      var fileStream = new FileStream(file, FileMode.Create);
      await Upload.CopyToAsync(fileStream);
    }
  }
}