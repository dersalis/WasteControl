using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WasteControl.Infrastructure.DAL
{
    internal sealed class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WasteControlDbContext>();
                dbContext.Database.Migrate();

                CreateUsers(dbContext);
                CreateReceivingCompanies(dbContext);
                CreateTransportCompanies(dbContext);
                CreateWastes(dbContext);
                CreateWasteExports(dbContext);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        private void CreateUsers(WasteControlDbContext dbContext)
        {
            var users = dbContext.Users.ToList();

            if(users.Any())
            {
                return;
            }

            users = FakeDataGenerator.GenerateUsers();
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }

        private void CreateReceivingCompanies(WasteControlDbContext dbContext)
        {
            var receivingCompanies = dbContext.ReceivingCompanies.ToList();

            if(receivingCompanies.Any())
            {
                return;
            }

            receivingCompanies = FakeDataGenerator.GenerateReceivingCompanies();
            dbContext.ReceivingCompanies.AddRange(receivingCompanies);
            dbContext.SaveChanges();
        }

        private void CreateTransportCompanies(WasteControlDbContext dbContext)
        {
            var transportCompanies = dbContext.TransportCompanies.ToList();

            if(transportCompanies.Any())
            {
                return;
            }

            transportCompanies = FakeDataGenerator.GenerateTransportCompanies();
            dbContext.TransportCompanies.AddRange(transportCompanies);
            dbContext.SaveChanges();
        }

        private void CreateWastes(WasteControlDbContext dbContext)
        {
            var wastes = dbContext.Wastes.ToList();

            if(wastes.Any())
            {
                return;
            }

            wastes = FakeDataGenerator.GenerateWastes();
            dbContext.Wastes.AddRange(wastes);
            dbContext.SaveChanges();
        }

        private void CreateWasteExports(WasteControlDbContext dbContext)
        {
            var wasteExports = dbContext.WasteExports.ToList();

            if(wasteExports.Any())
            {
                return;
            }

            wasteExports = FakeDataGenerator.GenerateWasteExports();
            dbContext.WasteExports.AddRange(wasteExports);
            dbContext.SaveChanges();
        }
    }
}