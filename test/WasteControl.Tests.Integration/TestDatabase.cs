using Microsoft.EntityFrameworkCore;
using WasteControl.Infrastructure.DAL;

namespace WasteControl.Tests.Integration
{
    internal class TestDatabase : IDisposable
    {
        public WasteControlDbContext Context { get; }

        public TestDatabase()
        {
            var postgresOptions = new OptionsProvider().Get<DataBaseOptions>("ConnectionStrings");
            Context = new WasteControlDbContext(new DbContextOptionsBuilder<WasteControlDbContext>()
                .UseNpgsql(postgresOptions.PostgresConnection)
                .Options);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}