using Microsoft.EntityFrameworkCore;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.Postgres
{
    public class PostgresUserRepository : IUserRepository
    {
        private readonly WasteControlDbContext _dbContext;

        public PostgresUserRepository(WasteControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContext.Remove(GetByIdAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _dbContext.Users
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .ToListAsync();

            return result.AsEnumerable();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Users
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .FirstOrDefaultAsync(u => u.Id == (ID)id);

            return result;
        }

        public async Task<User> GetByEmailAsync(Email email)
        {
            var result = await _dbContext.Users
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .FirstOrDefaultAsync(u => u.Email == email);

            return result;
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByLoginAsync(Login login)
        {
            var result = await _dbContext.Users
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .FirstOrDefaultAsync(u => u.Login == login);

            return result;
        }
    }
}