using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.InMemory
{
    public class InMemoryWasteExportRepository : IRepository<WasteExport>
    {
        private readonly List<WasteExport> _wasteExports;

        public InMemoryWasteExportRepository()
        {
            _wasteExports = FakeDataGenerator.GenerateWasteExports();
        }

        public Task AddAsync(WasteExport entity)
        {
            _wasteExports.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _wasteExports.RemoveAll(w => w.Id == (ID)id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<WasteExport>> GetAllAsync()
            => Task.FromResult(_wasteExports.AsEnumerable());

        public Task<WasteExport> GetAsync(Guid id)
            => Task.FromResult(_wasteExports.FirstOrDefault(w => w.Id == (ID)id));

        public Task UpdateAsync(WasteExport entity)
            => Task.CompletedTask;
    }
}