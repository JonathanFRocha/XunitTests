using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace calculations.tests
{
    public class CustomerTests
    {
        [Fact]
        public void NameNotEmpty()
        {
            var customer = new Customer();
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void checkLegitimateForDiscount()
        {
            var customer = new Customer();
            Assert.InRange(customer.Age, 25, 40);
        }
    }
}
