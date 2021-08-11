using Xunit;

namespace calculations.tests
{
    public class CalculatorTest
    {
        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            Calculator calc = new Calculator();
            int result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_GivenTwoDoubleValues_returnsDouble()
        {
            Calculator calc = new Calculator();
            double result = calc.addDouble(1.5, 2);
            Assert.Equal(3.5, result);
        }
    }
}
