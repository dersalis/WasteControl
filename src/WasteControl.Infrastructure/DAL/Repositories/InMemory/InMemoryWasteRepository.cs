using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.InMemory
{
    public class InMemoryWasteRepository : IRepository<Waste>
    {
        private readonly List<Waste> _wastes;

        public InMemoryWasteRepository()
        {
            _wastes = FakeDataGenerator.GenerateWastes();
        }

        public Task AddAsync(Waste entity)
        {
            _wastes.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _wastes.RemoveAll(w => w.Id == (ID)id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Waste>> GetAllAsync()
            => Task.FromResult(_wastes.AsEnumerable());

        public Task<Waste> GetAsync(Guid id)
            => Task.FromResult(_wastes.FirstOrDefault(w => w.Id == (ID)id));

        public Task UpdateAsync(Waste entity)
            => Task.CompletedTask;
    }
}