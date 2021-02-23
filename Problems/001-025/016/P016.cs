using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    

    // 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    // What is the sum of the digits of the number 2^1000?

    public class P016 : ISolution<long>
    {
        public long Solve()
        {
            var strDigits = Math.Pow(2, 1000).ToString("F0").ToCharArray();
            var longDigits = strDigits.Select(x => long.Parse("" + x));
            return longDigits.Sum();
        }
    }
}
