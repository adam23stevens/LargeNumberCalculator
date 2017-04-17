using Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concrete
{
    public class CalcFiler : ICalcFiler
    {        
        private const string FileLocation = @"C:\AdamStevens_InterouteTest";
        private const string FilePath = FileLocation + @"\Calculations.txt";       

        const string headers = "Timestamp | Number 1 | Operator | Number 2 | Result";

        private string WriteCalcLine(Calculation calculationObj)
        {
            string calcLine = $"{calculationObj.LogTime.ToString("dd-MM-yy HH:mm")} | " +
                              $"{calculationObj.Number1} | " +
                              $"{calculationObj.Operand} | " +
                              $"{calculationObj.Number2} | " +
                              $" = {calculationObj.Result}";

            return calcLine;
        }

        private void WriteAllToPath(string lines)
        {
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(FileLocation);                                                               
            }            
            File.WriteAllText(FilePath, lines); 
        }        

        public void LogError(string errorMsg)
        {
            string errorLine = $"{DateTime.Now.ToString("dd-MM-yy HH:mm")} - {errorMsg}";

            File.AppendAllText(FileLocation, errorLine);
        }

        public void UpdateFiles(Task<IEnumerable<Calculation>> task)
        {
            List<Calculation> ret = task.Result as List<Calculation>;

            StringBuilder sb = new StringBuilder();
            ret.ForEach(r => {
                sb.AppendLine(headers);
                sb.AppendLine(WriteCalcLine(r));
                }
            );

            WriteAllToPath(sb.ToString());
        }
    }
}
