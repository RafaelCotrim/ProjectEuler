using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // The sum of the squares of the first ten natural numbers is,
    // 1^2+2^2+...+10^2=385
    //
    // The square of the sum of the first ten natural numbers is,
    // (1+2+...+10)^2=552=3025
    //
    // Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025−385=2640.
    //
    // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    // Link:
    // https://projecteuler.net/problem=6
    public class P006 : ISolution<long>
    {
        public long Solve()
        {
            var s = Sum(100);
            return (s * s) - SumOfSquares(100);
        }

        private long Sum(long n)
        {
            return ((1 + n) * n) / 2;
        }

        private long SumOfSquares(long n)
        {
            return (n * (n + 1) * ((2 * n) + 1)) / 6;
        }
    }

    
}
