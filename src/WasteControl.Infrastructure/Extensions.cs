using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(swagger => 
            {
                swagger.EnableAnnotations();
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WasteControl API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMidelware>();

            app.UseSwagger();
            app.UseSwaggerUI();
            // app.UseReDoc(reDoc => 
            // {
            //     reDoc.RoutePrefix = "docs";
            //     reDoc.DocumentTitle = "WasteControl API";
            //     reDoc.SpecUrl = "/swagger/v1/swagger.json";
            // });

            return app;
        }
    }

}