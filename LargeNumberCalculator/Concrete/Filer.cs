using Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Concrete
{
    public class Filer : IFiler
    {
        public Filer()
        {
            if (!File.Exists(FileLocation))
            {
                InitFile();
            }
        }

        public string FileLocation
        {
            get
            {
                return @"C:\AdamStevens_InterouteTest\Calculations.txt";
            }            
        }        

        public void AppendToFile(Calculation calculationObj)
        {
            string calcLine = $"{calculationObj.LogTime.ToString("dd-MM-yy HH:mm")} | " +                              
                              $"{calculationObj.Number1} | " +
                              $"{calculationObj.Operand} | " +
                              $"{calculationObj.Number2} | " +                              
                              $" = {calculationObj.Result}";

            File.AppendAllText(FileLocation, calcLine);
        }

        public void InitFile()
        {
            const string headers = "Timestamp | Number 1 | Operator | Number 2 | Result";

            File.WriteAllText(FileLocation, headers);
        }

        public void LogError(string errorMsg)
        {
            string errorLine = $"{DateTime.Now.ToString("dd-MM-yy HH:mm")} - {errorMsg}";

            File.AppendAllText(FileLocation, errorLine);
        }
    }
}
