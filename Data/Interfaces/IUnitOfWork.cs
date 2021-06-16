using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IHistoryRepository HistoryRepository { get; }
        ITestRepository TestRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        Task SaveAsync();
    }
}
