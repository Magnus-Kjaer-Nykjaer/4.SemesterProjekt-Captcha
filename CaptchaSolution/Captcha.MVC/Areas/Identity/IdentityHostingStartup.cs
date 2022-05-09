using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Captcha.MVC.Areas.Identity.IdentityHostingStartup))]
namespace Captcha.MVC.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) =>
      {
      });
    }
  }
}