using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositoties
{
    public class HistoryRepository : IHistoryRepository
    {
        TestDbContext db;
        public HistoryRepository(TestDbContext context)
        {
            db = context;
        }
        public async Task AddAsync(History entity)
        {
            await db.Histories.AddAsync(entity);
        }

        public void Delete(History entity)
        {
            db.Histories.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            History history = await this.GetByIdAsync(id);
            if (history != null)
                db.Histories.Remove(history);
        }

        public IEnumerable<History> GetAll()
        {
            return db.Histories;
        }

        public async Task<History> GetByIdAsync(int id)
        {
            return await db.Histories.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<History>> GetByUserIdWithDetailsAsync(int userId)
        {
            return await db.Histories.Where(h => h.UserId == userId).Include(h => h.Test).ToListAsync();
        }

        public async Task<IEnumerable<History>> GetAllWithDetailsAsync()
        {
            return await db.Histories.Include(h => h.User).Include(h => h.Test).ToListAsync();
        }

        public void Update(History entity)
        {
            db.Histories.Update(entity);
        }
    }
}
