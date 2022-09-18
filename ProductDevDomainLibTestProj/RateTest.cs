using ProductDevDomainLib.Val;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class RateTest
    {
        [Fact]
        public void Rateは値オブジェクト()
        {
            var rate = new Rate(1);
            Assert.Equal(new Rate(1), rate);
        }

        [Fact]
        public void Rateは0から1の範囲()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rate(-0.01));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rate(1.01));
        }
    }
}
