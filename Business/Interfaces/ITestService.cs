using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ITestService: ICrud<TestModel>
    {
        Task<TestModel> GetByIdWithDetailsAsync(int id);
    }
}
