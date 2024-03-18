using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;
using WasteControl.Infrastructure.DAL;
using WasteControl.Infrastructure.Exceptions;
using WasteControl.Infrastructure.Security;

namespace WasteControl.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ExceptionMidelware>();
            services.AddPostgres(configuration);
            services
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddSingleton<IPasswordManager, PasswordManager>();

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMidelware>();
            return app;
        }
    }

}