using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstract
{
    public interface ICalculationRepo
    {
        void AddCalculationResult(Calculation calculationObj);
        Task<IEnumerable<Calculation>> GetCalculationResults();
    }
}
