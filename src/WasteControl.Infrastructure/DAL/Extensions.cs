using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;
using WasteControl.Infrastructure.DAL.Repositories.InMemory;

namespace WasteControl.Infrastructure.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = configuration.GetOptions<DataBaseOptions>("ConnectionStrings");

            services.AddDbContext<WasteControlDbContext>(options => options.UseNpgsql(dbOptions.PostgresConnection));

            services.AddScoped<IRepository<Waste>, InMemoryWasteRepository>();
            services.AddScoped<IRepository<ReceivingCompany>, InMemoryReceivingCompanyRepository>();
            services.AddScoped<IRepository<TransportCompany>, InMemoryTransportCompanyRepository>();
            services.AddScoped<IRepository<WasteExport>, InMemoryWasteExportRepository>();
            services.AddScoped<IRepository<User>, InMemoryUserRepository>();

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