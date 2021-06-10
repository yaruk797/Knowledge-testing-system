using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        //GetByName
        IEnumerable<Test> GetAllWithDetails();
    }
}
