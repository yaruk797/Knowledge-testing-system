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
    public class TestService : ITestService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        public TestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TestModel model)
        {
            await Database.TestRepository.AddAsync(_mapper.Map<Test>(model));
            await Database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await Database.TestRepository.DeleteByIdAsync(modelId);
            await Database.SaveAsync();
        }

        public IEnumerable<TestModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TestModel>>(Database.TestRepository.GetAll());
        }

        public async Task<TestModel> GetByIdWithDetailsAsync(int id)
        {
            return _mapper.Map<TestModel>(await Database.TestRepository.GetByIdWithDetailsAsync(id));
        }

        public async Task<TestModel> GetByIdAsync(int id)
        {
            return _mapper.Map<TestModel>(await Database.TestRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(TestModel model)
        {
            Database.TestRepository.Update(_mapper.Map<Test>(model));
            await Database.SaveAsync();
        }
    }
}
