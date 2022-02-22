using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure
{
    public static class Injectcion
    {
        public static IServiceCollection RegisterInfrastructerServices(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<MisionDbContext>(
                options =>
                    options.UseSqlite(
                        configuration.GetConnectionString("MisionDb")));
            service.AddTransient<IMisionRepository, MisionRepository>();
            return service;
        }
    }
}
