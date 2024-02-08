using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.InMemory
{
    public class InMemoryTransportCompanyRepository : IRepository<TransportCompany>
    {
        private readonly List<TransportCompany> _transportCompanies;

        public InMemoryTransportCompanyRepository()
        {
            _transportCompanies = FakeDataGenerator.GenerateTransportCompanies();
        }

        public Task AddAsync(TransportCompany entity)
        {
            _transportCompanies.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _transportCompanies.RemoveAll(w => w.Id == (ID)id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TransportCompany>> GetAllAsync()
            => Task.FromResult(_transportCompanies.AsEnumerable());

        public Task<TransportCompany> GetAsync(Guid id)
            => Task.FromResult(_transportCompanies.FirstOrDefault(w => w.Id == (ID)id));

        public Task UpdateAsync(TransportCompany entity)
            => Task.CompletedTask;
    }
}