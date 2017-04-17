using Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

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

        private const string FileLocation = @"C:\AdamStevens_InterouteTest";
        private const string FilePath = FileLocation + @"\Calculations.txt";       

        const string headers = "Timestamp | Number 1 | Operator | Number 2 | Result";

        public void AppendToFile(Calculation calculationObj)
        {
            string calcLine = $"{calculationObj.LogTime.ToString("dd-MM-yy HH:mm")} | " +
                              $"{calculationObj.Number1} | " +
                              $"{calculationObj.Operand} | " +
                              $"{calculationObj.Number2} | " +
                              $" = {calculationObj.Result}";

            File.AppendAllText(FileLocation, calcLine);
        }

        private void InitFile()
        {
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(FileLocation);                
                //FileStream fs = new FileStream(FilePath, FileMode.CreateNew);

                File.WriteAllText(FilePath, headers);                
            }            
        }        

        public void LogError(string errorMsg)
        {
            string errorLine = $"{DateTime.Now.ToString("dd-MM-yy HH:mm")} - {errorMsg}";

            File.AppendAllText(FileLocation, errorLine);
        }
    }
}
