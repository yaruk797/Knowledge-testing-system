using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(QuestionModel model)
        {
            await Database.QuestionRepository.AddAsync(_mapper.Map<Question>(model));
            await Database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await Database.QuestionRepository.DeleteByIdAsync(modelId);
            await Database.SaveAsync();
        }

        public IEnumerable<QuestionModel> GetAll()
        {
           return _mapper.Map<IEnumerable<QuestionModel>>(Database.QuestionRepository.GetAll());
        }

        public async Task<QuestionModel> GetByIdAsync(int id)
        {
            return _mapper.Map<QuestionModel>(await Database.QuestionRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<QuestionModel>> GetByTestIdWithDetailsAsync(int testId)
        {
            return _mapper.Map<IEnumerable<QuestionModel>>(await Database.QuestionRepository.GetByTestIdWithDetailsAsync(testId));
        }

        public async Task UpdateAsync(QuestionModel model)
        {
            Database.QuestionRepository.Update(_mapper.Map<Question>(model));
            await Database.SaveAsync();
        }
    }
}
