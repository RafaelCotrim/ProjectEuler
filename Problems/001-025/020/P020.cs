using Guaraci.Core.Numeric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
    

    //n! means n × (n − 1) × ... × 3 × 2 × 1

    //For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    //and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

    //Find the sum of the digits in the number 100!

    public class P020 : ISolution<int>
    {
        public int Solve()
        {
            return ExtraMath.BigFactorial(100).ToString().Select(x => Int32.Parse("" + x)).Sum();
        }
    }
}
