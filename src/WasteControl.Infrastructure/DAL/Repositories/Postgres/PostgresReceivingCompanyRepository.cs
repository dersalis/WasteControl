using Microsoft.EntityFrameworkCore;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.Postgres
{
    public class PostgresReceivingCompanyRepository : IRepository<ReceivingCompany>
    {
        private readonly WasteControlDbContext _dbContext;

        public PostgresReceivingCompanyRepository(WasteControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ReceivingCompany entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContext.Remove(GetAsync(id));

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReceivingCompany>> GetAllAsync()
        {
            var result = await _dbContext.ReceivingCompanies
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .ToListAsync();

            return result.AsEnumerable();
        }

        public Task<ReceivingCompany> GetAsync(Guid id)
        {
            var result = _dbContext.ReceivingCompanies
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .FirstOrDefaultAsync(w => w.Id == (ID)id);
            
            return result;
        }

        public async Task UpdateAsync(ReceivingCompany entity)
        {
            _dbContext.Update(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}