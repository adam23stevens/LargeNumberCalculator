using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface IFiler
    {                
        string WriteCalcLine(Calculation CalculationObj);        
        void LogError(string errorMsg);
        void UpdateFiles(Task<IEnumerable<Calculation>> task);
    }
}
