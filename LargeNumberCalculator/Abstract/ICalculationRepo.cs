using Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Abstract
{
    public interface ICalculationRepo
    {
        void AddCalculationResult(Calculation calculationObj);
        IEnumerable<Calculation> GetCalculationResults();
    }
}
