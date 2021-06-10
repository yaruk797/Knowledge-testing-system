using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface ITestService: ICrud<TestModel>
    {
        IEnumerable<TestModel> GetAllWithDetails();
    }
}
