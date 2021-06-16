using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Question : BaseEntity
    {
        public string Name { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
