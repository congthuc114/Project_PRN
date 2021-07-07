using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_QLSP.Areas.Identity.Data;
using Project_QLSP.Data;

[assembly: HostingStartup(typeof(Project_QLSP.Areas.Identity.IdentityHostingStartup))]
namespace Project_QLSP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Project_QLSPContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Project_QLSPContextConnection")));

                services.AddDefaultIdentity<Project_QLSPUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Project_QLSPContext>();
            });
        }
    }
}