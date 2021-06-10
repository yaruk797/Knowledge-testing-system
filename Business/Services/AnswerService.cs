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
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(AnswerModel model)
        {
            await Database.AnswerRepository.AddAsync(_mapper.Map<Answer>(model));
            await Database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await Database.AnswerRepository.DeleteByIdAsync(modelId);
            await Database.SaveAsync();
        }

        public IEnumerable<AnswerModel> GetAll()
        {
            return _mapper.Map<IEnumerable<AnswerModel>>(Database.AnswerRepository.GetAll());
        }

        public async Task<AnswerModel> GetByIdAsync(int id)
        {
            return _mapper.Map<AnswerModel>(await Database.AnswerRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(AnswerModel model)
        {
            Database.AnswerRepository.Update(_mapper.Map<Answer>(model));
            await Database.SaveAsync();
        }
    }
}
