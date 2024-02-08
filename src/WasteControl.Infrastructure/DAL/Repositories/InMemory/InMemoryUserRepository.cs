using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.InMemory
{
    public class InMemoryUserRepository : IRepository<User>
    {
        private readonly List<User> _users;

        public InMemoryUserRepository()
        {
            _users = FakeDataGenerator.GenerateUsers();
        }

        public Task AddAsync(User entity)
        {
            _users.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _users.RemoveAll(u => u.Id == (ID)id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync()
            => Task.FromResult(_users.AsEnumerable());

        public Task<User> GetAsync(Guid id)
            => Task.FromResult(_users.FirstOrDefault(u => u.Id == (ID)id));

        public Task UpdateAsync(User entity)
            => Task.CompletedTask;
    }
}