using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.InMemory
{
    public class InMemoryReceivingCompanyRepository : IRepository<ReceivingCompany>
    {
        private readonly List<ReceivingCompany> _receivingCompanies;

        public InMemoryReceivingCompanyRepository()
        {
            _receivingCompanies = FakeDataGenerator.GenerateReceivingCompanies();
        }

        public Task AddAsync(ReceivingCompany entity)
        {
            _receivingCompanies.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _receivingCompanies.RemoveAll(w => w.Id == (ID)id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ReceivingCompany>> GetAllAsync()
            => Task.FromResult(_receivingCompanies.AsEnumerable());

        public Task<ReceivingCompany> GetAsync(Guid id)
            => Task.FromResult(_receivingCompanies.FirstOrDefault(w => w.Id == (ID)id));

        public Task UpdateAsync(ReceivingCompany entity)
            => Task.CompletedTask;
    }
}