using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WasteControl.Infrastructure.Auth;
using WasteControl.Infrastructure.DAL;
using WasteControl.Infrastructure.Exceptions;
using WasteControl.Infrastructure.Security;

namespace WasteControl.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSingleton<ExceptionMidelware>();
            services.AddHttpContextAccessor();
            
            services.AddPostgres(configuration);
            services.AddSecurity();

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

            services.AddAuth(configuration);

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

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }

}