using Abstract;
using System;
using Entities;
using System.Collections.Generic;
using Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Concrete
{
    public class CalculationRepo : ICalculationRepo
    {
        private CalcContext CalcContext { get; set; }        

        public CalculationRepo(CalcContext calcContext)
        {
            CalcContext = calcContext;            
        }

        public void AddCalculationResult(Calculation calculationObj)
        {
            CalcContext.Add(calculationObj);
            CalcContext.SaveChanges();
        }
        
        public async Task<IEnumerable<Calculation>> GetCalculationResults()
        {
            return await CalcContext.Calculations.ToListAsync();
        }
    }
}
