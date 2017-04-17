using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Abstract;
using Concrete;
using Entities;
using Newtonsoft.Json.Linq;

namespace LargeNumberCalculator.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CalculationController : Controller
    {
        ICalculationRepo calcRepo;
        ICalcFiler filer;

        public CalculationController(ICalculationRepo ICalcRepo, ICalcFiler Ifiler)
        {
            calcRepo = ICalcRepo;
            filer = Ifiler;
        }

        [HttpPost]
        [Route("AddNumbers")]
        public IActionResult AddNumbers([FromBody] NumberReq req)
        {            
            try
            {                
                var number1 = req.number1;
                var number2 = req.number2;

                OperatorService osService = new OperatorService(number1, number2);

                Calculation calculation = new Calculation();
                calculation.Number1 = number1;
                calculation.Number2 = number2;
                calculation.LogTime = DateTime.Now;
                calculation.Operand = osService.OperandString;
                calculation.Result = new OperatorService(number1, number2).Calculate();                

                calcRepo.AddCalculationResult(calculation);                
            }
            catch (Exception ex)
            {
                filer.LogError(ex.Message);                
            }                       

            return Ok();
        }

        [HttpPut]
        [Route("SaveFile")]
        public IActionResult SaveFile()
        {            
            filer.UpdateFiles(calcRepo.GetCalculationResults());

            return Ok();
        }

        [HttpGet]
        [Route("GetAllCalculations")]
        public async Task<IActionResult> GetAllCalculations()
        {
            var calculations = await calcRepo.GetCalculationResults();
            return Ok(calculations);
        }
    }
}