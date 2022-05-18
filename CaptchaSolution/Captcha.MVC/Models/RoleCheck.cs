using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Captcha.MVC.Models
{
  public class RoleCheck
  {
    private readonly ILogger<RoleCheck> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleCheck(RoleManager<IdentityRole> roleManager, ILogger<RoleCheck> logger)
    {
      _roleManager = roleManager;
      _logger = logger;
    }

    public async Task<bool> CheckRole(string roleName)
    {
      try
      {
        if (!await _roleManager.RoleExistsAsync(roleName))
          await _roleManager.CreateAsync(new IdentityRole(roleName));
        return true;

      }
      catch (Exception e)
      {
        _logger.LogError("{e}", e);
      }
      return false;
    }
  }
}
