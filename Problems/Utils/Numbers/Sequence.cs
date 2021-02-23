using ProjectEuler.Utils.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Utils.Numbers
{
    public class Sequence
    {

        public static long Triangle(long n)
        {
            return n * (n + 1) / 2;
        }

        /// <summary>
        /// Calculares the next number on the Collatz sequence based on the argument <code>n</code>
        /// </summary>
        /// <param name="n">The number whose next Collatz value is being calculated</param>
        /// <returns>The next Collatz value</returns>
        public static long Collatz(long n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            if (n % 2 == 0)
                return n / 2;

            return 3 * n + 1;
        }

    }
}
