using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace calculations.tests
{
    public class NameTests
    {
        [Fact]
        public void MakeFullNameTest()
        {
            Names makename = new Names();
            string result = makename.MakeFullName("Jonathan", "Ferreira");
            string expected = "Jonathan Ferreira";
            string expected3 = "Ferreira";
            Assert.Equal(expected, result);
            Assert.Contains(expected3, result);
        }

        [Fact]
        public void NickNameShouldBeNull()
        {
            Names names = new Names();
            Assert.Null(names.nickName);
        }
    }
}
