using Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Concrete
{
    public class OperateStringMultiply : OperateString
    {       
        public OperateStringMultiply(string number1, string number2) : base(number1, number2) { }

        public override string Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
