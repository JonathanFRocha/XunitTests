using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace calculations.tests
{
    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();
    }

    public class CalculationFixture
    {
        public Calculations Calc = new Calculations();
    }
    public class CalculationTests : IClassFixture<CalculatorFixture>,IClassFixture<CalculationFixture>, IDisposable
    {

        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MemoryStream memoryStream;
        private readonly CalculatorFixture _calculatorFixture;
        private readonly CalculationFixture _calculationFixture;

        public CalculationTests(ITestOutputHelper testOutputhelper, CalculatorFixture calculatorFixture, CalculationFixture calculationFixture)
        {
            _testOutputHelper = testOutputhelper;
            _testOutputHelper.WriteLine("Constructor");
            this._calculatorFixture = calculatorFixture;
            _calculationFixture = calculationFixture;
            memoryStream = new MemoryStream();
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            Calculator calc = _calculatorFixture.Calc;
            int result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void Add_GivenTwoDoubleValues_returnsDouble()
        {
            Calculator calc = _calculatorFixture.Calc;
            double result = calc.addDouble(1.5, 2);
            Assert.Equal(3.5, result);
        }

        [Fact]
        [Trait("Category", "Fibonachi")]
        public void FiboDoesNotIncludeZero()
        {
            _testOutputHelper.WriteLine("Check Fibo is Not Zero");
            Calculations calc = new Calculations();
            Assert.All(calc.FiboNumbers, (n) => Assert.NotEqual(0, n));
        }

        [Fact]
        [Trait("Category", "Fibonachi")]
        public void FiboIncludesThirteen()
        {
            _testOutputHelper.WriteLine("Check Fibo has 13");
            var calc = new Calculations();
            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibonachi")]
        public void FiboDoesNotIncludesFour()
        {
            _testOutputHelper.WriteLine("Check Fibo has 4");
            var calc = new Calculations();
            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibonachi")]
        public void checkCollection()
        {
            _testOutputHelper.WriteLine("Check collection");
            var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var calc = new Calculations();
            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }

        [Fact]
        public void IsOdd_GivenOddValue_ReturnsTrue()
        {
            var result = _calculationFixture.Calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        public void IsOdd_GivenEvenValue_ReturnsFalse()
        {
            var result = _calculationFixture.Calc.IsOdd(2);
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var result = _calculationFixture.Calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
