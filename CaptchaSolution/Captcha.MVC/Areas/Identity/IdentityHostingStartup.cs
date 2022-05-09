using System;
using Captcha.MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Captcha.MVC.Areas.Identity.IdentityHostingStartup))]
namespace Captcha.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CaptchaMVCContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("CaptchaMVCContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CaptchaMVCContext>();
            });
        }
    }
}