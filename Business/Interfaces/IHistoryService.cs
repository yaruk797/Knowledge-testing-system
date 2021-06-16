using Business.Models;
using Business.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IHistoryService : ICrud<HistoryModel>
    {
        Task<IEnumerable<HistoryViewModel>> GetByUserIdWithDetailsAsync(int userId);
        Task<IEnumerable<HistoryViewModel>> GetAllWithDetailsAsync();
    }
}
