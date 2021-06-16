using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Models.ViewModels;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class HistoryService : IHistoryService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;

        public HistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(HistoryModel model)
        {
            await Database.HistoryRepository.AddAsync(_mapper.Map<History>(model));
            await Database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await Database.HistoryRepository.DeleteByIdAsync(modelId);
            await Database.SaveAsync();
        }

        public IEnumerable<HistoryModel> GetAll()
        {
            return _mapper.Map<IEnumerable<HistoryModel>>(Database.HistoryRepository.GetAll());
        }

        public async Task<HistoryModel> GetByIdAsync(int id)
        {
            return _mapper.Map<HistoryModel>(await Database.HistoryRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<HistoryViewModel>> GetByUserIdWithDetailsAsync(int userId)
        {
            return _mapper.Map<IEnumerable<HistoryViewModel>>(await Database.HistoryRepository.GetByUserIdWithDetailsAsync(userId));
        }

        public async Task<IEnumerable<HistoryViewModel>> GetAllWithDetailsAsync()
        {
            return _mapper.Map<IEnumerable<HistoryViewModel>>(await Database.HistoryRepository.GetAllWithDetailsAsync());
        }

        public async Task UpdateAsync(HistoryModel model)
        {
            Database.HistoryRepository.Update(_mapper.Map<History>(model));
            await Database.SaveAsync();
        }
    }
}
