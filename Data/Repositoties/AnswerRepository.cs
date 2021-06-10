using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositoties
{
    public class AnswerRepository : IAnswerRepository
    {
        TestDbContext db;
        public AnswerRepository(TestDbContext context)
        {
            db = context;
        }
        public async Task AddAsync(Answer entity)
        {
            await db.Answers.AddAsync(entity);
        }

        public void Delete(Answer entity)
        {
            db.Answers.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Answer answer = await this.GetByIdAsync(id);
            if (answer != null)
                db.Answers.Remove(answer);
        }

        public IEnumerable<Answer> GetAll()
        {
            return db.Answers;
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await db.Answers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Update(Answer entity)
        {
            db.Answers.Update(entity);
        }
    }
}
