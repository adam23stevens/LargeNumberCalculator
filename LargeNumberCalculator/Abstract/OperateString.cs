using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract
{
    public abstract class OperateString
    {
        protected string Number1 { get; set; }
        protected string Number2 { get; set; }

        public abstract string Calculate();

        public OperateString(string number1, string number2)
        {
            if (!IsValidNumberStr(number1) || !IsValidNumberStr(number2))
            {
                throw new Exception("Invalid numbers in request");
            }
            else
            {
                Number1 = number1;
                Number2 = number2;
            }
        }        

        protected int GetInt(char c)
        {
            try
            {
                return int.Parse(c.ToString());            
            }
            catch
            {
                throw new Exception("invalid number found in string");
            }
        }

        private bool IsValidNumberStr(string numStr)
        {
            const string regexPattern = "^[0-9]*$";
            return System.Text.RegularExpressions.Regex.IsMatch(numStr.Substring(1, numStr.Length - 1), regexPattern);
        }
    }
}
