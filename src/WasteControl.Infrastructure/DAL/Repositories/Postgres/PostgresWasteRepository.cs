using Microsoft.EntityFrameworkCore;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.Postgres
{
    public class PostgresWasteRepository : IRepository<Waste>
    {
        private readonly WasteControlDbContext _dbContext;

        public PostgresWasteRepository(WasteControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Waste entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContext.Remove(GetAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Waste>> GetAllAsync()
        {
            var result = await _dbContext.Wastes
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .ToListAsync();

            return result.AsEnumerable();
        }

        public Task<Waste> GetAsync(Guid id)
        {
            var result = _dbContext.Wastes
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .FirstOrDefaultAsync(u => u.Id == (ID)id);

            return result;
        }

        public Task UpdateAsync(Waste entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}