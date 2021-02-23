﻿using Guaraci.Core.Numeric.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // The sequence of triangle numbers is generated by adding the natural numbers.So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. 
    // The first ten terms would be:
    // 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    // Let us list the factors of the first seven triangle numbers:

    // 1: 1
    // 3: 1,3
    // 6: 1,2,3,6
    // 10: 1,2,5,10
    // 15: 1,3,5,15
    // 21: 1,3,7,21
    // 28: 1,2,4,7,14,28

    // We can see that 28 is the first triangle number to have over five divisors.
    // What is the value of the first triangle number to have over five hundred divisors?

    // Link:
    // https://projecteuler.net/problem=12
    public class P012 : ISolution<long>
    {
        public long Solve()
        {
            var factorizer = new CachedFactorizer();
            factorizer.Search(65500);
            var i = 1;
            long div;
            long n;
            do
            {
                n = Triangle(i);
                var powers = factorizer.PrimePowers(n);
                div = powers.Select(x => x.power).Aggregate((long)1, (mul, next) => mul * (next + 1));
                i += 1;
            } while (div < 500);
            return n;
        }

        private long Triangle(long n)
        {
            return n * (n + 1) / 2;
        }
    }
}
