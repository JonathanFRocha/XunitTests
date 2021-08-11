using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace calculations.tests
{
    public class CalculationTests
    {
        [Fact]
        public void FiboDoesNotIncludeZero()
        {
            Calculations calc = new Calculations();
            Assert.All(calc.FiboNumbers, (n) => Assert.NotEqual(0, n));
        }

        [Fact] 
        public void FiboIncludesThirteen()
        {
            var calc = new Calculations();
            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        public void FiboDoesNotIncludesFour()
        {
            var calc = new Calculations();
            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        public void checkCollection()
        {
            var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var calc = new Calculations();
            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }
    }
}
