using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IQuestionService : ICrud<QuestionModel>
    {
        Task<IEnumerable<QuestionModel>> GetByTestIdWithDetailsAsync(int testId);
    }
}
