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
        public void FeatureRequestはIDを持ち_完了するとFeatureになる()
        {
            var request = new FeatureRequest("some_id");
            Assert.Equal("some_id", request.Id);
            Assert.Equal(new Feature("some_id"), request.Done());
        }

        [Fact]
        public void FeatureRequestはストーリーポイントを持つ()
        {
            var request = new FeatureRequest("some_id", storyPoint:new Progress(3));
            Assert.Equal(new Progress(3), request.StoryPoint);
        }
    }
}
