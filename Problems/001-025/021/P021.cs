using Guaraci.Core.Numeric.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectEuler
{
    

    //Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    //If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called 
    // amicable numbers.

    //For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; 
    //therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

    //Evaluate the sum of all the amicable numbers under 10000.

    public class P021 : ISolution<long>
    {

        private CachedFactorizer factorizer = new CachedFactorizer();

        public long Solve()
        {
            factorizer.Search(100);
            var nums = Enumerable.Range(2, 10000);
            var divSum = nums.Select(x =>
            {
                var a = DivisorSum(x);
                var b = DivisorSum(a);
                return new { n = x, divSum = a, ami = b};
            });
            var amicablePairs = divSum.Where(x => x.n == x.ami && x.n != x.divSum);
            var amicable = new HashSet<long>();
            foreach (var a in amicablePairs)
            {
                amicable.Add(a.n);
                amicable.Add(a.divSum);
            }

            return amicable.Sum();
        }

        public long DivisorSum(long n)
        {
            var powers = factorizer.PrimePowers(n);
            long result = 1;
            foreach (var p in powers)
            {
                long sum = 0;
                for (int i = 0; i <= p.power; i++)
                {
                    sum += (long)Math.Pow(p.prime, i);
                }
                result *= sum;
            }
            return result - n;

        }
    }
}
