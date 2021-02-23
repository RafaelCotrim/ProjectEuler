using ProjectEuler.Utils.Numbers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProjectEuler.Test.Utils
{

    public class FactorizerTest
    {
        [Fact]
        public void AtikinSieve_Values()
        {
            var fact = new Factorizer();

            Assert.Equal(new long[] { 2, 3, 5, 7 }, fact.AtikinSieve(10));
            Assert.Equal(new long[] { 2, 3, 5, 7, 11, 13, 17, 19 }, fact.AtikinSieve(20));
        }

        [Fact]
        public void SmallestMultiple_Values()
        {
            var fact = new Factorizer();
            Assert.Equal(2520, fact.SmallestMultiple(1, 10));
            Assert.Equal(232792560, fact.SmallestMultiple(1, 20));
        }
    }
}
