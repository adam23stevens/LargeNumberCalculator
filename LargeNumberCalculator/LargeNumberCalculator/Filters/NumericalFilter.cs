using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LargeNumberCalculator.Filters
{
    public class NumericalFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string number1 = context.ActionArguments["number1"].ToString();
            string number2 = context.ActionArguments["number2"].ToString();

            if (!IsValidNumberStr(number1) || !IsValidNumberStr(number2))
            {
                //return bad request
                
            }            
        }        

        private bool IsValidNumberStr(string numStr)
        {
            const string regexPattern = "^[0-9]*$";
            return System.Text.RegularExpressions.Regex.IsMatch(numStr.Substring(1, numStr.Length - 1), regexPattern);
        }
    }
}
