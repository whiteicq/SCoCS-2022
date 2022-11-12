using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web_053504_Belko.Data;
using Web_053504_Belko.Entities;

[assembly: HostingStartup(typeof(Web_053504_Belko.Areas.Identity.IdentityHostingStartup))]
namespace Web_053504_Belko.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });

        }
    }
}