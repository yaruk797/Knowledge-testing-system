using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Answer: BaseEntity
    {
        public string Name { get; set; }
        public bool IsRight { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
