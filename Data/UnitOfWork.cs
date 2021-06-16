using Data.Interfaces;
using Data.Repositoties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private TestDbContext db;

        private UserRepository userRepository;
        private HistoryRepository historyRepository;
        private TestRepository testRepository;
        private QuestionRepository questionRepository;

        public UnitOfWork(TestDbContext context)
        {
            db = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IHistoryRepository HistoryRepository
        {
            get
            {
                if (historyRepository == null)
                    historyRepository = new HistoryRepository(db);
                return historyRepository;
            }
        }

        public ITestRepository TestRepository
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(db);
                return questionRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
