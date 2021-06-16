using Business.Interfaces;
using Business.Models;
using Business.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private IHistoryService _historyService;

        public HistoriesController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [Authorize]
        [HttpGet("history")]
        public async Task<IEnumerable<HistoryViewModel>> GetHistory()
        {
            var userId = Int32.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var histories = await _historyService.GetByUserIdWithDetailsAsync(userId);
            
            return histories;
        }

        [Authorize]
        [HttpGet("histories")]
        public async Task<IEnumerable<HistoryViewModel>> GetHistories()
        {
            var histories = await _historyService.GetAllWithDetailsAsync();
            
            return histories;
        }
    }
}
