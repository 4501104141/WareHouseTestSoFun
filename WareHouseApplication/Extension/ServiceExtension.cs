using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
             services.AddDbContext<WareHouseDbContext>(opts =>
             opts.UseSqlServer(configuration.GetConnectionString("MyDB")));
    }
}