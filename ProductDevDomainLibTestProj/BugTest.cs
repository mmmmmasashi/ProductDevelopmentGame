using ProductDevDomainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class BugTest
    {
        [Fact]
        public void Bugは単位時間あたりの発生確率を持つ()
        {
            var bug = new Bug("ID1", new Rate(0.01));
            Assert.Equal(new Rate(0.01), bug.EventProbability);
        }
    }
}
