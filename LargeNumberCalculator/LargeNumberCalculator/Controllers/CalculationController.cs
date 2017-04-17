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
        IFiler filer;

        public CalculationController(ICalculationRepo ICalcRepo, IFiler Ifiler)
        {
            calcRepo = ICalcRepo;
            filer = Ifiler;
        }

        [HttpPost]
        public IActionResult AddNumbers(string number1, string number2)
        {                        
            try
            {
                OperatorService osService = new OperatorService(number1, number2);

                Calculation calculation = new Calculation();
                calculation.Number1 = number1;
                calculation.Number2 = number2;
                calculation.LogTime = DateTime.Now;
                calculation.Operand = osService.OperandString;
                calculation.Result = new OperatorService(number1, number2).Calculate();                

                calcRepo.AddCalculationResult(calculation);
                filer.AppendToFile(calculation);
            }
            catch (Exception ex)
            {
                filer.LogError(ex.Message);                
            }                       

            return Ok();
        }
    }
}