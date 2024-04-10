using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WasteControl.Application.Implementations;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            
            return services;
        }
    }
}