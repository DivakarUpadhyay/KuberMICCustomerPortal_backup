using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(KuberMICManager.WebUI.Areas.Identity.Pages.Users.Client.WebUI.Areas.Identity.IdentityHostingStartup))]
namespace KuberMICManager.WebUI.Areas.Identity.Pages.Users.Client.WebUI.Areas.Identity
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