using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class History : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public int Result { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
    }
}
