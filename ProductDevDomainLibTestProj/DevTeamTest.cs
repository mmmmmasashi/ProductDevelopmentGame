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


    }
}