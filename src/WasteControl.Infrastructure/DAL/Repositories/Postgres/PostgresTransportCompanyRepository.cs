using Microsoft.EntityFrameworkCore;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.Postgres
{
    public class PostgresTransportCompanyRepository : IRepository<TransportCompany>
    {
        private readonly WasteControlDbContext _dbContext;

        public PostgresTransportCompanyRepository(WasteControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TransportCompany entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContext.Remove(GetAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransportCompany>> GetAllAsync()
        {
            var result = await _dbContext.TransportCompanies
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .ToListAsync();

            return result.AsEnumerable();
        }

        public async Task<TransportCompany> GetAsync(Guid id)
        {
            var result = await _dbContext.TransportCompanies
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .FirstOrDefaultAsync(u => u.Id == (ID)id);

            return result;
        }

        public async Task UpdateAsync(TransportCompany entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}