using Abstract;
using System;
using Entities;
using System.Collections.Generic;
using Data;
using System.IO;
using System.Linq;

namespace Concrete
{
    public class CalculationRepo : ICalculationRepo
    {
        private const string FileLocation = @"C:\AdamStevens\CalculationTest\Calculations.txt";

        public CalculationRepo()
        {
            if (!File.Exists(FileLocation))
            {
                const string headers = "Timestamp | Number 1 | Number 2 | Result";

                File.WriteAllText(FileLocation, headers);                
            }
        }

        public void AddCalculationResult(Calculation calculationObj)
        {
            string calcLine = $"{calculationObj.LogTime.ToString("dd-MM-yy HH:mm")} | " +
                              $"{calculationObj.Number1} | " +
                              $"{calculationObj.Number2} | " +
                              $"{calculationObj.Result}";

            File.AppendAllText(FileLocation, calcLine);
        }
        
        public IEnumerable<Calculation> GetCalculationResults()
        {
            var ret = new List<Calculation>();
            File.ReadAllLines(FileLocation).ToList().ForEach(cl =>
            {
                var line = cl.Trim().Split('|');
                Calculation calc = new Calculation
                {
                    LogTime = Convert.ToDateTime(line[0]),
                    Number1 = line[1],
                    Number2 = line[2],
                    Result = line[4]
                };
                ret.Add(calc);
            });
            return ret;
        }
    }
}
