using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;

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
