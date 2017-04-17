using Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Concrete
{
    public sealed class OperatorService
    {
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        private Operand operand;
        public string OperandString {get
            {
                switch(operand)
                {
                    case Operand.Addition:
                        return "+";                        
                    case Operand.Subtraction:
                        return "-";                        
                    case Operand.Multiplication:
                        return "*";                        
                    case Operand.Division:
                        return @"/";                        
                    default:
                        return "";                        
                }
            }
        }
        private OperateString operateStr { get; set; } 

        public OperatorService(string number1, string number2)
        {
            Number1 = number1;
            Number2 = number2;
            /*
            Find out which operand to use.

            if neither or both numbers negative then operandAdd            
            otherwise operandSubtract.
            Todo - work out when to use the other operators
            */                        
            if ((Number1[0] == '-' && Number2[0] == '-')
             || (Number1[0] != '-' && Number2[0] != '-'))
            {
                operand = Operand.Addition;
            }
            else
            {
                operand = Operand.Subtraction;
            }            
        }

        public string Calculate()
        {
            switch(operand)
            {
                case Operand.Addition:
                    operateStr = new OperateStringAdd(Number1, Number2);
                    break;

                case Operand.Subtraction:                               
                    operateStr = new OperateStringSubtract(Number1, Number2);
                    break;

                case Operand.Multiplication:
                    operateStr = new OperateStringMultiply(Number1, Number2);
                    break;

                case Operand.Division:
                    operateStr = new OperateStringDivide(Number1, Number2);
                    break;                                
            }            
            try
            {
                var result = operateStr.Calculate();
                return result;
            }
            catch(Exception ex)
            {             
                throw new Exception(ex.Message);
            }
        }        

        private enum Operand
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }
    }
}
