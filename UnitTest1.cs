using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xunit;

namespace Velocity
{
    public class UnitTest1
    {
        private VelocityTester _tester = new VelocityTester();

        [Fact]
        public void SinglePeriod()
        {
            int result = _tester.Count(1, 3, 5);
            Assert.Equal(1, result);
        }

        [Fact]
        public void NoPeriod()
        {
            int result = _tester.Count(1, 3, 6);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FourVelocitiesConstantOverThreeItemsReturnsOne()
        {
            int result = _tester.Count(1, 3, 5, 10);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TwoVelocitiesReturnsZero()
        {
            int result = _tester.Count(1, 3);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FourVelocitiesConstantOverLastThreeItemsReturnsOne()
        {
            int result = _tester.Count(10, 1, 3, 5);
            Assert.Equal(1, result);
        }

        [Fact]
        public void SixVelocitiesWithTwoConstantRunsReturnsTwo()
        {
            int result = _tester.Count(1, 2, 3, 11, 12, 13);
            Assert.Equal(2, result);
        }

        [Fact]
        public void FourVelocitiesWithThreeRunsReturnsThree()
        {
            int result = _tester.Count(1, 2, 3, 4);
            Assert.Equal(3, result);
        }

        [Fact]
        public void SixVelocitiesWithThreeRunsReturnsTen()
        {
            int result = _tester.Count(1, 2, 3, 4, 5, 6);
            Assert.Equal(10, result);
        }

        [Fact]
        public void ThreeLongConstantRunsReturnCorrectResult()
        {
            int result = _tester.Count(1, 2, 3, 4, 5, 6, 1, 2, 3, 1, 2, 3, 4);
            Assert.Equal(14, result);
        }

        [Fact]
        public void ArrayLengthOf10000WithTwosReturns49985001()
        {
            int result = _tester.Count(Enumerable.Repeat(2, 10000).ToArray());
            Assert.Equal(49985001, result);
        }
    }


    public class VelocityTester
    {
        public int Count(params int[] m) =>
            m.Length < 3 ? 0 :
                m.Zip(m[1..],(c, s) => c - s)
                                .Aggregate((r: 0, l: (int?)null, s: 0),
                                            (t, d) => (t.l == d ? ++t.r : 0, d, t.s + (t.l == d ? t.r : 0))).s;
    }
}
