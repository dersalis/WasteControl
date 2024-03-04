using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;
using WasteControl.Infrastructure.DAL.Repositories.InMemory;
using WasteControl.Infrastructure.DAL.Repositories.Postgres;

namespace WasteControl.Infrastructure.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = configuration.GetOptions<DataBaseOptions>("ConnectionStrings");

            services.AddDbContext<WasteControlDbContext>(options => options.UseNpgsql(dbOptions.PostgresConnection));

            services.AddScoped<IRepository<Waste>, InMemoryWasteRepository>();
            // services.AddScoped<IRepository<ReceivingCompany>, InMemoryReceivingCompanyRepository>();
            // services.AddScoped<IRepository<TransportCompany>, InMemoryTransportCompanyRepository>();
            // services.AddScoped<IRepository<WasteExport>, InMemoryWasteExportRepository>();
            // services.AddScoped<IRepository<User>, InMemoryUserRepository>();

            services.AddScoped<IRepository<ReceivingCompany>, PostgresReceivingCompanyRepository>();
            services.AddScoped<IRepository<TransportCompany>, PostgresTransportCompanyRepository>();
            services.AddScoped<IRepository<Waste>, PostgresWasteRepository>();
            services.AddScoped<IRepository<WasteExport>, PostgresWasteExportRepository>();
            services.AddScoped<IRepository<User>, PostgresUserRepository>();

            services.AddHostedService<DatabaseInitializer>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
            return services;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName)
        where T : class, new()
        {
            var options = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}