using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.Security
{
    public static class Extensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddSingleton<IPasswordManager, PasswordManager>();

            return services;
        }
    }
}