using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositoties
{
    public class TestRepository : ITestRepository
    {
        TestDbContext db;
        public TestRepository(TestDbContext context)
        {
            db = context;
        }
        public async Task AddAsync(Test entity)
        {
            await db.Tests.AddAsync(entity);
        }

        public void Delete(Test entity)
        {
            db.Tests.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Test test = await this.GetByIdAsync(id);
            if (test != null)
                db.Tests.Remove(test);
        }

        public IEnumerable<Test> GetAll()
        {
            return db.Tests;
        }

        public IEnumerable<Test> GetAllWithDetails()
        {
            return db.Tests.Include(t => t.Questions).ToList();
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await db.Tests.FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Update(Test entity)
        {
            db.Tests.Update(entity);
        }
    }
}
