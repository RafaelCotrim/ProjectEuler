using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
    // Numbers in numbers.txt

    // Link:
    // https://projecteuler.net/problem=13
    public class P013 : ISolution<string>
    {
        public string Solve()
        {
            BigInteger sum = BigInteger.Zero;
            var line = "";
            using (var f = new StreamReader(@".\\001-025\\013\\numbers.txt"))
            {
                while ((line = f.ReadLine()) != null)
                {
                    sum += BigInteger.Parse(line);
                }
            }
            return sum.ToString().Substring(0, 10);
        }
    }
}
