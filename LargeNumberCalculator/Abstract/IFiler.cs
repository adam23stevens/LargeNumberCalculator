using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract
{
    public interface IFiler
    {        
        string FileLocation { get; }        
        void AppendToFile(Calculation CalculationObj);
        void InitFile();
        void LogError(string errorMsg);
    }
}
