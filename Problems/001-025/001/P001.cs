using Guaraci.Core.Numeric.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{

    // Problem:

    // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
    // The sum of these multiples is 23.
    // Find the sum of all the multiples of 3 or 5 below 1000.

    // Link: https://projecteuler.net/problem=1


    public class P001 : ISolution<long>
    {
        public long Solve()
        {
            var mult3 = ArithmeticSequence.MultipleSequence(3);
            var mult5 = ArithmeticSequence.MultipleSequence(5);
            var mult15 = ArithmeticSequence.MultipleSequence(3 * 5);
            return mult3.GetTermsBellow(1000).Sum() + mult5.GetTermsBellow(1000).Sum() - mult15.GetTermsBellow(1000).Sum();
        }
    }
}
