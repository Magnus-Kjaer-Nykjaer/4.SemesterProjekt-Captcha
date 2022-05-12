using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Captcha.MVC.Models
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelModel : PageModel
    {

    }
}

