using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TestId { get; set; }
        public string UserAnswer { get; set; }
        public List<AnswerModel> Answers { get; set; }
        //public List<int> AnswerIds { get; set; }
    }
}
