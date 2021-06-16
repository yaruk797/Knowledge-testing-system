using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<QuestionModel> Questions { get; set; }
        public List<int> UserIds { get; set; }

    }
}
