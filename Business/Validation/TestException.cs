using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{
    public class TestException : Exception
    {
        public TestException(string message) : base(message) { }
    }
}
