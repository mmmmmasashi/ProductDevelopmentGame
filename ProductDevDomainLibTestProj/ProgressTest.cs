using ProductDevDomainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class ProgressTest
    {
        [Fact]
        public void ProgressはValueObject()
        {
            var progress = new Progress(3);
            Assert.Equal(3.0M, progress.Value);
            Assert.Equal(new Progress(3), progress);
        }

        [Fact]
        public void Progressは正()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Progress(-0.1M));
        }

    }
}
