using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Utils.Numbers
{
    public class Operations
    {
        public static long Factorial(long n)
        {
            long result = 1;
            for (long i = n; i > 1; i--)
            {
                result *= i;
            }
            return result;
        }

        public static BigInteger BigFactorial(long n, long factDenominator = 1)
        {
            var result = BigInteger.One;
            for (long i = n; i > factDenominator; i--)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Calculates the number of permuatiions of a set of n elements where r are chosen each time
        /// </summary>
        /// <param name="n">Total number of elements</param>
        /// <param name="r">Legth of the permutation</param>
        /// <returns></returns>
        public static long Permutation(long n, long r)
        {
            if (n < 0 || r < 0)
                throw new ArgumentException();

            if (n < r)
                throw new ArgumentException("The number of elements must be equal or greater than the legth of the permutation");

            return Factorial(n) / Factorial(n - r);
        }
    }
}
