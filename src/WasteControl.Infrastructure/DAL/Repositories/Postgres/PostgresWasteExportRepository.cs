using Microsoft.EntityFrameworkCore;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.Postgres
{
    public class PostgresWasteExportRepository : IRepository<WasteExport>
    {
        private readonly WasteControlDbContext _dbContext;

        public PostgresWasteExportRepository(WasteControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(WasteExport entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContext.Remove(GetAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WasteExport>> GetAllAsync()
        {
            var result = await _dbContext.WasteExports
                .Include(c => c.TransportCompany)
                .Include(c => c.ReceivingCompany)
                .Include(w => w.Wastes)
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .ToListAsync();

            return result.AsEnumerable();
        }

        public async Task<WasteExport> GetAsync(Guid id)
        {
            var result = await _dbContext.WasteExports
                .Include(c => c.TransportCompany)
                .Include(c => c.ReceivingCompany)
                .Include(w => w.Wastes)
                .Include(u => u.CreatedBy)
                .Include(u => u.ModifiedBy)
                .FirstOrDefaultAsync(u => u.Id == (ID)id);

            return result;
        }

        public async Task UpdateAsync(WasteExport entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}