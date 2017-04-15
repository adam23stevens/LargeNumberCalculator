using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Abstract;
using Concrete;
using Entities;

namespace LargeNumberCalculator.Controllers
{
    [Produces("application/json")]
    [Route("api/Calculation")]
    public class CalculationController : Controller
    {
        ICalculationRepo calcRepo;

        public CalculationController(ICalculationRepo ICalcRepo)
        {
            calcRepo = ICalcRepo;
        }

        [HttpPost]
        public IActionResult AddNumbers(string number1, string number2)
        {
            Calculation calculation = new Calculation();
            calculation.Number1 = number1;
            calculation.Number2 = number2;
            calculation.LogTime = DateTime.Now;
            
            //find out which operand to use.
            //if neither or both numbers negative then operandAdd
            //otherwise operandSubtract
            OperateString operandStr;

            if ((number1[0] == '-' && number2[0] == '-') 
             || (number1[0] != '-' && number2[0] != '-'))
            {
                operandStr = new OperateStringAdd(number1[0] == '-' && number2[0] == '-');
            }
            else
            {                
                operandStr = new OperateStringSubtract();
            }

            try
            {
                var result = operandStr.Calculate(number1, number2);
                calculation.Result = result;
            }
            catch
            {
                //Todo - add this into repo instead?
                throw new Exception("There has been an error calculating. Please try again");                
            }

            calcRepo.AddCalculationResult(calculation);

            return Ok();
        }
    }
}