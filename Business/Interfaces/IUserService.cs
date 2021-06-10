using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService : ICrud<UserModel>
    {
        Task<UserModel> GetByUsernameAndPasswordAsync(string username, string password);
    }
}
