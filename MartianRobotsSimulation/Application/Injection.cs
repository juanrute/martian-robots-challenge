using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Injectcion
    {
        public static IServiceCollection RegisterApplicationServices(
            this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return service;
        }
    }
}
