using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class P025 : ISolution<long>
    {
        public long Solve()
        {
            return LargeIndex();
        }

        private long LargeIndex()
        {
            BigInteger secondToLast = BigInteger.Zero;
            BigInteger last = BigInteger.One;
            BigInteger buffer;
            long i = 1;
            while(last.ToString().Length < 1000)
            {
                buffer = secondToLast;
                secondToLast = last;
                last = buffer + secondToLast;
                i++;
            }
            return i;
            
        }
    }
}
