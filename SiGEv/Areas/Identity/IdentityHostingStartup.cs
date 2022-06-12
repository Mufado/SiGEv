using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiGEv.Data;
using SiGEv.Models;

[assembly: HostingStartup(typeof(SiGEv.Areas.Identity.IdentityHostingStartup))]
namespace SiGEv.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<SiGEvContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.AllowedUserNameCharacters = "aãâáàbcdeéèêfghiíìîjklmnoóòõôpqrstuûúùvwxyzAÃÂÁÀBCDEÈÊÉFGHIÌÍÎJKLMNOÓÒÕÔPQRSTUÚÙÛVWXYZ0123456789-._@+";
                })
                    .AddRoles<IdentityRole<int>>()
                    .AddEntityFrameworkStores<SiGEvContext>();
            });
        }
    }
}