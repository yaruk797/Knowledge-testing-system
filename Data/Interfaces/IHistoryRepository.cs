using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IHistoryRepository : IRepository<History>
    {
        Task<IEnumerable<History>> GetByUserIdWithDetailsAsync(int userId);
        Task<IEnumerable<History>> GetAllWithDetailsAsync();
    }
}
