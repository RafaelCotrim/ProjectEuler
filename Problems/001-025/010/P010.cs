using Guaraci.Core.Numeric.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    // Find the sum of all the primes below two million.

    // Link:
    // https://projecteuler.net/problem=10
    public class P010 : ISolution<long>
    {
        public long Solve()
        {
            var sieve = new AtikinSieve();
            return sieve.Search(2000000).Sum();
        }
    }
}
