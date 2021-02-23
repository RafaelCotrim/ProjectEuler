using Guaraci.Core.Numeric;
using Guaraci.Core.Numeric.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    // What is the 10 001st prime number?
    // Link:
    // https://projecteuler.net/problem=7
    public class P007 : ISolution<long>
    {
        public long Solve()
        {
            var sieve = new AtikinSieve();
            // TODO use prime-counting function to lower the upper bound
            var primes = sieve.Search(200000); 
            return primes.ElementAt(10001 - 1);
        }
    }
}
