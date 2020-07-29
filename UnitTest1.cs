using System;
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
            int result = _tester.CountVelocityPeriods(1, 3, 5);
            Assert.Equal(1, result);
        }

        [Fact]
        public void NoPeriod()
        {
            int result = _tester.CountVelocityPeriods(1, 3, 6);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FourVelocitiesConstantOverThreeItemsReturnsOne()
        {
            int result = _tester.CountVelocityPeriods(1, 3, 5, 10);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TwoVelocitiesReturnsZero()
        {
            int result = _tester.CountVelocityPeriods(1, 3);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FourVelocitiesConstantOverLastThreeItemsReturnsOne()
        {
            int result = _tester.CountVelocityPeriods(10, 1, 3, 5);
            Assert.Equal(1, result);
        }

        [Fact]
        public void SixVelocitiesWithTwoConstantRunsReturnsTwo()
        {
            int result = _tester.CountVelocityPeriods(1, 2, 3, 11, 12, 13);
            Assert.Equal(2, result);
        }

        [Fact]
        public void FourVelocitiesWithThreeRunsReturnsThree()
        {
            int result = _tester.CountVelocityPeriods(1, 2, 3, 4);
            Assert.Equal(3, result);
        }

        [Fact]
        public void SixVelocitiesWithThreeRunsReturnsTen()
        {
            int result = _tester.CountVelocityPeriods(1, 2, 3, 4, 5, 6);
            Assert.Equal(10, result);
        }

        [Fact]
        public void ThreeLongConstantRunsReturnCorrectResult()
        {
            int result = _tester.CountVelocityPeriods(1, 2, 3, 4, 5, 6, 1, 2, 3, 1, 2, 3, 4);
            Assert.Equal(14, result);
        }

        [Fact]
        public void ArrayLengthOf10000WithTwosReturns49985001()
        {
            int result = _tester.CountVelocityPeriods(Enumerable.Repeat(2, 10000).ToArray());
            Assert.Equal(49985001, result);
        }
    }

    public class VelocityTester
    {
        public int CountVelocityPeriods(params int[] measurements)
        {
            if (measurements.Length < 3) return 0;


            var currentDiff = measurements[1] - measurements[0];
            var currentCounter = 0;
            var total = 0;
            for (var m = 1; m < measurements.Length - 1; m++)
            {
                var thisDiff = measurements[m + 1] - measurements[m];
                if (thisDiff == currentDiff)
                {
                    currentCounter++;
                    total  +=  currentCounter;
                }
                else
                {
             //       total += AddCurrent(currentCounter);

                    currentCounter = 0;
                    currentDiff = thisDiff;
                }
            }

     //       total += AddCurrent(currentCounter);

            return total;

            //                             *    1 2*3
            // Length 2 => 3              * *   1 2*3*4
            // Length 3 => 6             * * *
            // Length 4 => 10           * * * *
            // Length 5 => 10         * * * * * *

        }

        private int AddCurrent(int currentCounter)
        {
            return currentCounter  *  (currentCounter  +  1)  /  2;
            //var total = 0;
            //for (int i = 1; i <= currentCounter; i++)
            //    total += i;
            //return total;

            // T = (n)(n + 1) / 2
            //(n / 2)(first number + last number)
        }
    }
}
