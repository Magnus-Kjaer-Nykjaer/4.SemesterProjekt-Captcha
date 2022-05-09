using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Captcha.MVC.Models
{
  [Authorize(Policy = "Admin")]
  public class UploadFileModel : PageModel
  {
    private IWebHostEnvironment _environment;
    public UploadFileModel(IWebHostEnvironment environment)
    {
      _environment = environment;
    }
    [BindProperty]
    public IFormFile Upload { get; set; }
    public async Task OnPostAsync()
    {
      var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
      using (var fileStream = new FileStream(file, FileMode.Create))
      {
        await Upload.CopyToAsync(fileStream);
      }
    }
  }
}