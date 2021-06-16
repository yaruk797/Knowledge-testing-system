using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.ViewModels
{
    public class HistoryViewModel
    {
        public string DateTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public int Result { get; set; }
        public string TestName { get; set; }
        public string UserName { get; set; }
    }
}
