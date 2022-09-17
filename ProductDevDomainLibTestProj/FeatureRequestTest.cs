using ProductDevDomainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class FeatureRequestTest
    {
        [Fact]
        public void FeatureRequestを生成できる()
        {
            var request = new FeatureRequest("some_id");
            Assert.Equal("some_id", request.Id);
        }
    }
}
