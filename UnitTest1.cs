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
    }

    public class VelocityTester
    {
        public int CountVelocityPeriods(params int[] measurements)
        {
            if (measurements.Length < 3) return 0;

            var currentDiff = measurements[1] - measurements[0];
            var currentCounter = 0;
            var total = 0;
            for (var m = 1; m < measurements.Length-1; m++)
            {
                var thisDiff = measurements[m + 1] - measurements[m];
                if (thisDiff == currentDiff)
                {
                    currentCounter++;
                }
                else
                {
                    if (currentCounter == 1)
                        total+=1;

                    if (currentCounter == 2)
                        total += 3;

                    currentCounter  =  0;
                    currentDiff = thisDiff;
                }
            }

            if (currentCounter == 1)
                total += 1;

            if (currentCounter == 2)
                total += 3;

            return total;
        }
    }
}
