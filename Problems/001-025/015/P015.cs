using Guaraci.Core.Numeric;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
    //Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, 
    //there are exactly 6 routes to the bottom right corner.
    //How many such routes are there through a 20×20 grid?
    public class P015 : ISolution<BigInteger>
    {
        public BigInteger Solve()
        {
            return ExtraMath.BigCombination(40, 20);
        }
    }
}
