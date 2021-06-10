using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<History> Users { get; set; }
    }
}
