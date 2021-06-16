using Microsoft.Extensions.Configuration;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private ITestService _testService;
        private IHistoryService _historyService;

        public TestsController(ITestService testService, IHistoryService historyService)
        {
            _testService = testService;
            _historyService = historyService;
        }
        
        [HttpGet("tests")]
        public IEnumerable<TestModel> GetTests()
        {
            return _testService.GetAll();
        }

        [HttpGet("test/{id}")]
        public async Task<TestModel> GetTest(int id)
        {
            return await _testService.GetByIdWithDetailsAsync(id);
        }

        [HttpPost("result")]
        public async Task<IActionResult> GetTestResult([FromBody] QuestionModel[] questionModels)
        {
            int result = 0;
            TestModel test = await _testService.GetByIdWithDetailsAsync(questionModels.FirstOrDefault().TestId);

            for (var i = 0; i < test.Questions.Count; i++)
            {
                for (var j = 0; j < test.Questions[i].Answers.Count; j++)
                {
                    if (test.Questions[i].Answers[j].IsRight &&
                        test.Questions[i].Answers[j].Name == questionModels[i].UserAnswer)
                        result++;
                }
            }

            if (User.HasClaim(h => h.Type == ClaimTypes.NameIdentifier))
            {
                var userId = Int32.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
                HistoryModel history = new HistoryModel()
                {
                    DateTime = DateTime.Now,
                    NumberOfQuestions = questionModels.Length,
                    Result = result,
                    TestId = questionModels.FirstOrDefault().TestId,
                    UserId = userId
                };
                await _historyService.AddAsync(history);
            }

            return Ok(result);
        }
    }
}
