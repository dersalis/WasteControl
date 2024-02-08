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
            services.AddScoped<IRepository<Waste>, InMemoryWasteRepository>();
            services.AddScoped<IRepository<ReceivingCompany>, InMemoryReceivingCompanyRepository>();
            services.AddScoped<IRepository<TransportCompany>, InMemoryTransportCompanyRepository>();
            services.AddScoped<IRepository<WasteExport>, InMemoryWasteExportRepository>();
            services.AddScoped<IRepository<User>, InMemoryUserRepository>();
            
            return services;
        }
    }
}