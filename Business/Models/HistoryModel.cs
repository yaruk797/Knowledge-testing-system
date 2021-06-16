using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class HistoryModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public int Result { get; set; }
        public UserModel User { get; set; }
        public int UserId { get; set; }
        public TestModel Test { get; set; }
        public int TestId { get; set; }
    }
}
