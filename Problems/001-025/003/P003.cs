using Guaraci.Core.Numeric.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // The prime factors of 13195 are 5, 7, 13 and 29.
    // What is the largest prime factor of the number 600851475143 ?
    // Link: https://projecteuler.net/problem=3

    public class P003 : ISolution<long>
    {
        public long Solve()
        {
            // TODO change to hybrid (fermant +  trial) factorization or simple checking
            return new TrialFactorizer().Factorize(600851475143).OrderBy(x => x).Last();
        }
    }
}
