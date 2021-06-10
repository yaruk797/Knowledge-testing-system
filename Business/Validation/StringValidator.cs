using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{
    public static class StringValidator
    {
        public static bool IsValid(params string[] arr)
        {
            bool flag = true;
            foreach(var s in arr)
                if (string.IsNullOrEmpty(s))
                    flag = false;

            return flag;
        }
    }
}
