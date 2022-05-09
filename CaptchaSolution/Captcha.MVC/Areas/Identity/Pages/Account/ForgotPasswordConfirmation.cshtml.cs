using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Captcha.MVC.Areas.Identity.Pages.Account
{
  [AllowAnonymous]
  public class ForgotPasswordConfirmation : PageModel
  {
    public void OnGet()
    {
    }
  }
}
