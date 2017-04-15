using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract
{
    public abstract class OperateString
    {
        public abstract string Calculate(string number1, string number2);
        
        protected int GetInt(char c)
        {
            return Convert.ToInt32(c);
        }
    }
}
