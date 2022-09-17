using ProductDevDomainLib;
using System;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class DevTeamTest
    {
        [Fact]
        public void Velocity�͐�()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(velocity: -0.1));
        }

        [Fact]
        public void Error��������0�ȏ�1�ȉ�()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(errorRate: -0.01));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(errorRate: 1.01));
        }

        [Fact]
        public void Velocity1��1�P�ʎ��Ԏd���������FeatureRequest��Feature�Ɋ������ďo�Ă���()
        {
            var team = new DevTeam(velocity: 1, errorRate: 0);

            team.RequestFeature(new FeatureRequest("SAMPLE_ID"));

            Output output = team.Work();

            Assert.Single(output.Features);
            Assert.Equal(new Feature("SAMPLE_ID"), output.Features[0]);
        }


    }
}