using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Models.ViewModels;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(UserModel model)
        {
            await Database.UserRepository.AddAsync(_mapper.Map<User>(model));
            await Database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await Database.UserRepository.DeleteByIdAsync(modelId);
            await Database.SaveAsync();
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserModel>>(Database.UserRepository.GetAll());
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return _mapper.Map<UserModel>(await Database.UserRepository.GetByIdAsync(id));
        }

        public async Task<UserModel> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return _mapper.Map<UserModel>(await Database.UserRepository
                        .GetByUsernameAndPasswordAsync(username, password));
        }

        public async Task UpdateAsync(UserModel model)
        {
            Database.UserRepository.Update(_mapper.Map<User>(model));
            await Database.SaveAsync();
        }
    }
}
