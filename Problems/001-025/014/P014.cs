using Guaraci.Core.Numeric.Sequences;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    //The following iterative sequence is defined for the set of positive integers:
    //n → n/2 (n is even)
    //n → 3n + 1 (n is odd)
    //Using the rule above and starting with 13, we generate the following sequence:
    //13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    //It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    //Which starting number, under one million, produces the longest chain?
    //NOTE: Once the chain starts the terms are allowed to go above one million.
    public class P014 : ISolution<long>
    {
        private Dictionary<long, long> _memory = new Dictionary<long, long>();
        public long Solve()
        {
            var max = 0;
            long maxLen = 0;
            for (int i = 500000; i < 1000000; i++)
            {
                var ret = CollatzLengt(i);
                if (ret > maxLen)
                {
                    max = i;
                    maxLen = ret;
                }
            }
            return max;
        }

        private long CollatzLengt(long n)
        {
            long len = 0;
            var original = n;
            while (n > 1)
            {
                if (_memory.TryGetValue(n, out long value))
                {
                    return len + value;
                }
                len++;
                n = SequenceUtilities.Collatz(n);
            }
            len++;
            _memory[original] = len;
            return len;

        }
    }
}
