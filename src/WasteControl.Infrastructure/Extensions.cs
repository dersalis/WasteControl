using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WasteControl.Infrastructure.DAL;
using WasteControl.Infrastructure.Exceptions;

namespace WasteControl.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ExceptionMidelware>();
            services.AddPostgres(configuration);

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMidelware>();
            return app;
        }
    }

}