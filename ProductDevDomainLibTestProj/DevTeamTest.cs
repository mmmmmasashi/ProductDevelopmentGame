using ProductDevDomainLib;

namespace ProductDevDomainLibTestProj
{
    public class DevTeamTest
    {
        [Fact]
        public void Velocity1��1�P�ʎ��Ԏd���������FeatureRequest��Feature�Ɋ������ďo�Ă���()
        {
            double velocity = 1;
            double errorRate = 0;
            var team = new DevTeam(velocity, errorRate);

            team.RequestFeature(new FeatureRequest("SAMPLE_ID"));

            Output output = team.Work();

            Assert.Single(output.Features);
            Assert.Equal(new Feature("SAMPLE_ID"), output.Features[0]);
        }
    }
}