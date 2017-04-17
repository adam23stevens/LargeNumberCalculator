using Abstract;
using System;

namespace Concrete
{
    public class OperateStringAdd : OperateString
    {
        public OperateStringAdd(string number1, string number2) : base(number1, number2) { }

        private bool IsNeg { get; set; }

        public override string Calculate()
        {
            IsNeg = Number1[0] == '-' && Number2[0] == '-';
            RemoveSigns();

            int cnt1 = Number1.Length - 1;
            int cnt2 = Number2.Length - 1;
            string res = ""; //result to return     
            int carry = 0;   //remainder from digit addition

            for (; cnt1 >= 0 || cnt2 >= 0; cnt1--, cnt2--)
            {
                int digitAdd = 0;
                if (cnt1 >= 0 && cnt2 >= 0)
                {
                    digitAdd = GetInt(Number1[cnt1]) + GetInt(Number2[cnt2]) + carry;
                }
                else if (cnt1 >= 0)
                {
                    digitAdd = GetInt(Number1[cnt1]) + carry;
                }
                else if (cnt2 >= 0)
                {
                    digitAdd = GetInt(Number2[cnt2]) + carry;
                }

                res += digitAdd % 10;
                carry = digitAdd / 10;
            }

            res += IsNeg ? "-" : "";
            char[] retArray = res.ToCharArray();
            Array.Reverse(retArray);
            return new string(retArray);
        }

        private void RemoveSigns()
        {
            Number1 = Number1.Replace("-", "");
            Number2 = Number2.Replace("-", "");
        }
    }
}
