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
    public class QuestionRepository : IQuestionRepository
    {
        TestDbContext db;
        public QuestionRepository(TestDbContext context)
        {
            db = context;
        }

        public async Task AddAsync(Question entity)
        {
            await db.Questions.AddAsync(entity);
        }

        public void Delete(Question entity)
        {
            db.Questions.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Question question = await this.GetByIdAsync(id);
            if (question != null)
                db.Questions.Remove(question);
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await db.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Question>> GetByTestIdWithDetailsAsync(int testId)
        {
            return await db.Questions.Where(q => q.TestId == testId).ToListAsync();
        }

        public void Update(Question entity)
        {
            db.Questions.Update(entity);
        }
    }
}
