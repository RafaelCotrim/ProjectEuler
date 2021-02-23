using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProjectEuler.Test
{
    public class SolutionTest
    {
        #region 001-025
        [Fact]
        public void P001_Solution()
        {
            Assert.Equal(233168, new P001().Solve());
        }

        [Fact]
        public void P002_Solution()
        {
            Assert.Equal(4613732, new P002().Solve());
        }

        [Fact]
        public void P003_Solution()
        {
            Assert.Equal(6857, new P003().Solve());
        }

        [Fact]
        public void P004_Solution()
        {
            Assert.Equal(906609, new P004().Solve());
        }

        [Fact]
        public void P005_Solution()
        {
            Assert.Equal(232792560, new P005().Solve());
        }

        [Fact]
        public void P006_Solution()
        {
            Assert.Equal(25164150, new P006().Solve());
        }

        [Fact]
        public void P007_Solution()
        {
            Assert.Equal(104743, new P007().Solve());
        }

        [Fact]
        public void P008_Solution()
        {
            Assert.Equal(23514624000, new P008().Solve());
        }

        [Fact]
        public void P009_Solution()
        {
            Assert.Equal(31875000, new P009().Solve());
        }

        [Fact]
        public void P010_Solution()
        {
            Assert.Equal(142913828922, new P010().Solve());
        }

        [Fact]
        public void P011_Solution()
        {
            Assert.Equal(70600674, new P011().Solve());
        }

        [Fact]
        public void P012_Solution() 
        {
            Assert.Equal(76576500, new P012().Solve());
        }

        [Fact]
        public void P013_Solution()
        {
            Assert.Equal("5537376230", new P013().Solve());
        }

        [Fact]
        public void P014_Solution()
        {
            Assert.Equal(837799, new P014().Solve());
        }

        [Fact]
        public void P015_Solution()
        {
            Assert.Equal(137846528820, new P015().Solve());
        }

        [Fact]
        public void P016_Solution()
        {
            Assert.Equal(1366, new P016().Solve());
        }

        // TODO problem 17

        [Fact]
        public void P018_Solution()
        {
            Assert.Equal(1074, new P018().Solve());
        }

        [Fact]
        public void P019_Solution()
        {
            Assert.Equal(171, new P019().Solve());
        }

        [Fact]
        public void P020_Solution()
        {
            Assert.Equal(648, new P020().Solve());
        }

        [Fact]
        public void P021_Solution()
        {
            Assert.Equal(31626, new P021().Solve());
        }

        [Fact]
        public void P022_Solution()
        {
            Assert.Equal(871198282, new P022().Solve());
        }

        [Fact]
        public void P023_Solution()
        {
            Assert.Equal(4179871, new P023().Solve());
        }

        [Fact]
        public void P025_Solution()
        {
            Assert.Equal(4782, new P025().Solve());
        }

        #endregion

        #region 026-050

        [Fact]
        public void P026_Solution()
        {
            Assert.Equal(983, new P026().Solve());
        }

        #endregion


        #region 051-075
        [Fact]
        public void P067_Solution()
        {
            Assert.Equal(7273, new P067().Solve());
        }
        #endregion
    }
}
