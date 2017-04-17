using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract
{
    public interface IFiler
    {                
        void AppendToFile(Calculation CalculationObj);        
        void LogError(string errorMsg);
    }
}
