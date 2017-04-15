using Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Concrete
{
    public class OperateStringAdd : OperateString
    {
        private bool IsNeg { get; set; }

        public OperateStringAdd(bool isNeg) {
            IsNeg = isNeg;
        }
        
        public override string Calculate(string number1, string number2)
        {
            int cnt1 = number1.Length - 1;
            int cnt2 = number2.Length - 1;
            string res = ""; //result to return     
            int carry = 0;   //remainder from digit addition

            for (; cnt1 >= 0 || cnt2 >= 0; cnt1--, cnt2--)
            {
                int digitAdd = 0;
                if (cnt1 >= 0 && cnt2 >= 0)
                {
                    digitAdd = GetInt(number1[cnt1]) + GetInt(number2[cnt2]) + carry;
                }
                else if (cnt1 >= 0)
                {
                    digitAdd = GetInt(number1[cnt1]) + carry;
                }
                else if (cnt2 >= 0)
                {
                    digitAdd = GetInt(number2[cnt2]) + carry;
                }

                res += digitAdd % 10;
                carry = digitAdd / 10;
            }

            res += IsNeg ? "-" : ""; 
            char[] retArray = res.ToCharArray();
            Array.Reverse(retArray);
            return new string(retArray);
        }
    }
}
