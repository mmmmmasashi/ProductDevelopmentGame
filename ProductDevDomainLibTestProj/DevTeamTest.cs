using ProductDevDomainLib;
using System;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class DevTeamTest
    {
        [Fact]
        public void Velocityは正()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(velocity: -0.1));
        }

        [Fact]
        public void Error発生率は0以上1以下()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(errorRate: -0.01));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(errorRate: 1.01));
        }

        [Fact]
        public void Velocity1で1単位時間仕事をするとFeatureRequestがFeatureに完成して出てくる()
        {
            var team = new DevTeam(velocity: 1, errorRate: 0);

            team.RequestFeature(new FeatureRequest("SAMPLE_ID"));

            Output output = team.Work();

            Assert.Single(output.Features);
            Assert.Equal(new Feature("SAMPLE_ID"), output.Features[0]);
        }

        [Fact]
        public void Velocity3で1単位時間仕事をすると3Point分のアウトプットを出してくる()
        {
            var team = new DevTeam(velocity: 3, errorRate: 0);
            
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