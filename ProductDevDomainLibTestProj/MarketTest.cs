using ProductDevDomainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class MarketTest
    {

        [Fact]
        public void Market_発生確率100Percentのバグを埋め込むと_必ずバグ修正要求をOutputする()
        {
            var market = new Market();
            var product = new Product();
            product.Add(new Bug("ID1", new Rate(1.0)));
            market.Release(product);

            IEnumerable<BugFixRequest> bugFixRequests = market.SpendTime();
            Assert.Equal(new List<BugFixRequest>() { new BugFixRequest("ID1") }, bugFixRequests);
        }
    }
}
