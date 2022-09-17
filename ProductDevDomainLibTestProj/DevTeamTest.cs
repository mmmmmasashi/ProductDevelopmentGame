using ProductDevDomainLib;
using System;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class DevTeamTest
    {
        [Fact]
        public void Velocity1��1�P�ʎ��Ԏd���������FeatureRequest��Feature�Ɋ������ďo�Ă���()
        {
            var team = new DevTeam(errorRate: new Rate(0));

            team.RequestFeature(new FeatureRequest("SAMPLE_ID"));

            Output output = team.Work();

            Assert.Single(output.Features);
            Assert.Equal(new Feature("SAMPLE_ID"), output.Features[0]);
        }

        [Fact(Skip ="���Ƃ�")]
        public void Velocity3��1�P�ʎ��Ԏd���������3Point���̃A�E�g�v�b�g���o���Ă���()
        {
            var team = new DevTeam(velocity: new Progress(3), errorRate: new Rate(0));
            
            team.RequestFeature(new FeatureRequest("ID1"));
            team.RequestFeature(new FeatureRequest("ID2"));
            team.RequestFeature(new FeatureRequest("ID3"));
            team.RequestFeature(new FeatureRequest("ID4"));

            var output = team.Work();

            var features = output.Features;
            Assert.Equal(3, features.Count());
            Assert.Equal(new Feature("ID1"), features[0]);
            Assert.Equal(new Feature("ID2"), features[1]);
            Assert.Equal(new Feature("ID3"), features[2]);

        }
    }
}