using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Utils.Numbers
{
    public class Factorizer
    {

        private SortedSet<long> Primes = new SortedSet<long>();
        private long FullySearched = 7;

        public Factorizer()
        {
            Primes.Add(2);
            Primes.Add(3);
            Primes.Add(5);
            Primes.Add(7);
        }

        public long[] Factorize(long n, bool stopAfterFirst = false)
        {
            var factors = new List<long>();
            if (n == 0 || n == 1)
                return new long[] { };

            while (n % 2 == 0)
            {
                n /= 2;
                factors.Add(2);
                if(stopAfterFirst)
                {
                    if (n != 1)
                        factors.Add(n);

                    return factors.ToArray();
                }
            }
            return factors.Concat(FermantFactorizations(n, stopAfterFirst)).ToArray();
        }

        public long[] TrialFactorization(long n, long limit = 0, bool stopAfterFirst = false) 
        {
            if (n == 0 || n == 1)
                return new long[] { };
            else if (n < 0)
                n = -1 * n;

            if (Primes.Contains(n))
                return new long[] { n };
            
            var factors = new List<long>();

            foreach (var prime in Primes)
            {
                while (n % prime == 0)
                {
                    n /= prime;
                    factors.Add(prime);
                    if (stopAfterFirst)
                    {
                        if(n != 1)
                            factors.Add(n);
                        return factors.ToArray();
                    }
                }
            }


            if (limit == 0)
                limit = (long)Math.Sqrt(n);
            else
                limit = Math.Min((long)Math.Sqrt(n), limit);

            var starting = FullySearched;
            if (FullySearched % 2 == 0)
                starting = FullySearched + 1;

            for (var i = starting; i <= limit; i+= 2)
            {
                while(n % i == 0)
                {
                    n /= i;
                    factors.Add(i);
                    Primes.Add(i);

                    if (stopAfterFirst)
                    {
                        if (i > FullySearched)
                            FullySearched = i;

                        if (n != 1)
                            factors.Add(n);

                        return factors.ToArray();
                    }
                }
            }

            if(n != 1)
            {
                Primes.Add(n);
                factors.Add(n);
            }

            if(limit > FullySearched)
            {
                FullySearched = limit;
            }
            return factors.ToArray();
        }

        public long[] FermantFactorizations(long n, bool stopAfterFirst = true, double range = 0.1)
        {
            if (n == 0 || n == 1)
                return new long[] { };
            else if (n < 0)
                n = -1 * n;

            if (Primes.Contains(n))
                return new long[] { n };

            var a = (long)Math.Ceiling(Math.Sqrt(n));
            var b2 = a * a - n;
            var rangeLimit = (1 + range) * n;

            while(Math.Sqrt(b2) % 1 != 0)
            {
                a += 1;
                b2 = a * a - n;

                if (a > rangeLimit)
                    return TrialFactorization(n, (long)(rangeLimit - Math.Sqrt(rangeLimit * rangeLimit - n)), stopAfterFirst);
            }
            var b = (long)Math.Sqrt(b2);

            if (a - b == 1)
                return new long[] { a + b };

            if (!stopAfterFirst)
                return TrialFactorization(a + b).Concat(TrialFactorization(a - b)).ToArray();

            return new long[] { a - b, a + b };
            
        }

        public long[] PrimeSearch(long max)
        {
            return AtikinSieve(max);
        }

        public long[] SearchPrimesUltil(int amount)
        {

            if (amount <= Primes.Count)
                return Primes.Take(amount).ToArray();


            var found = Primes.ToList();

            var starting = FullySearched;
            if (FullySearched % 2 == 0)
                starting = FullySearched + 1;

            for (long i = starting; found.Count < amount; i += 2)
            {
                if (Factorize(i).Length == 1)
                {
                    found.Add(i);
                    Primes.Add(i);
                }
                    
            }

            FullySearched = found.Last();
            return found.ToArray();
        }
    
        public long[]  AtikinSieve(long max)
        {
            if (max <= FullySearched)
                return Primes.Where(x => x <= max).ToArray();

            var found = new List<long>();
            found.Add(2);
            found.Add(3);
            found.Add(5);
            found.Add(7);


            var sieve = new bool[max];

            for (var i = 0; i * i < max; i++)
            {
                for (var j = 0; j * j < max; j++)
                {

                    var n = 4 * (i * i) + (j * j);

                    if (n <= max && (n % 12 == 1 || n % 12 == 5))
                        sieve[n] ^= true;

                    n = 3 * (i * i) + (j * j);
                    if (n <= max && n % 12 == 7)
                        sieve[n] ^= true;

                    n = 3 * (i * i) - (j * j);
                    if(n <= max && i > j && n % 12 == 11)
                        sieve[n] ^= true;
                }
            }

            for (var i = 5; i * i < max; i++)
            {
                if (sieve[i])
                {
                    var k = i * i;
                    for (int j = k; j < max; j += k)
                        sieve[j] = false;
                }
            }

            for (var i = 11; i < max; i++)
            {
                if (sieve[i])
                {
                    found.Add(i);
                    Primes.Add(i);
                }
            }

            FullySearched = max;
            return found.ToArray();

        }

        public (long prime, int power)[] PrimePowers(long n)
        {
            var factors = Factorize(n);
            return factors.GroupBy(f => f).Select(f => (f.Key, f.Count())).OrderBy(f => f.Key).ToArray();
        }

        public long SmallestMultiple(int start, int end)
        {
            var factorPowers = new List<(long prime, int power)>();
            for (int i = start; i <= end; i++)
            {
                factorPowers.AddRange(PrimePowers(i));
            }
            
            var maxFactors = factorPowers.GroupBy(fp => fp.prime).Select(fp => fp.Max());
            long multiple = 1;
            foreach (var fp in maxFactors)
            {
                multiple *= (long)Math.Pow(fp.prime, fp.power);
            }
            return multiple;
        }

        public bool IsPrime(long n)
        {
            return Primes.Contains(n) || Factorize(n, true).Length == 1;
        }
    
        public int DivisorCount(long n)
        {
            var powers = PrimePowers(n).Select(p => p.power);
            var comb = 1;
            foreach (var p in powers)
            {
                comb *= (p + 1);
            }
            return comb;
        }
    }
}
