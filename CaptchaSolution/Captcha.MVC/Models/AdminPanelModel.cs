using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Models
{
  [Authorize(Roles = "Admin")]
  public class AdminPanelModel : PageModel
  {
    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public IFormFile Upload { get; set; }

  }
}


