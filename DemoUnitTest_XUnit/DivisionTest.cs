using DemoUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest_XUnit
{
    public class DivisionTest
    {
        [Fact]
        public void DivisionValeurOk()
        {
            Calcul c = new Calcul();
            Assert.Equal(2.5, c.Division(5, 2));
        }

        [Fact]
        public void DivisionParZero() 
        {
            Calcul c = new Calcul();
            Assert.Throws<DivideByZeroException>(() => c.Division(5, 0));
        }

        [Theory]
        [InlineData(5,2)]
        [InlineData(4,2)]
        public void DivisionVerifType(int nb1, int nb2)
        {
            Calcul c = new Calcul();
            Assert.IsType<double>(c.Division(nb1,nb2));
        }
    }
}
