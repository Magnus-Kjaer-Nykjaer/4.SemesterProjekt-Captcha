using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Captcha.MVC.Models
{
  public class RoleCheck
  {

    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleCheck(RoleManager<IdentityRole> roleManager)
    {
      _roleManager = roleManager;
    }

    public async Task<bool> CheckRole(string roleName)
    {
      if (!await _roleManager.RoleExistsAsync(roleName))
        await _roleManager.CreateAsync(new IdentityRole(roleName));
      return true;
    }
  }
}
