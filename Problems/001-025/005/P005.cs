using Guaraci.Core.Numeric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    // Link:
    // https://projecteuler.net/problem=5

    public class P005 : ISolution<long>
    {
        public long Solve()
        {
            var nums = new List<long>();
            for (int i = 1; i <= 20; i++)
            {
                nums.Add(i);
            }
            return ExtraMath.LCM(nums);
        }
    }
}
