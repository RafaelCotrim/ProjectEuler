using Guaraci.Core.Numeric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class P024 : ISolution<long>
    {
        // TODO problem 24
        public long Solve()
        {
            long seachItem = 1000000;
            var digits = Enumerable.Range(0, 10).ToList();
            var str = "";

            for (int i = 9; i > 0; i--)
            {
                var fac = ExtraMath.Factorial(i);
                var index = (int)(seachItem / fac);
                str += digits.ElementAt(i);
                digits.RemoveAt(index);
                seachItem %=  fac;
            }
            str += digits.Last();
            return long.Parse(str);
        }
    }
}
