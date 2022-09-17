using ProductDevDomainLib;

namespace ProductDevDomainLibTestProj
{
    public class DevTeamTest
    {
        [Fact]
        public void Velocity1‚Å1’PˆÊŠÔd–‚ğ‚·‚é‚ÆFeatureRequest‚ªFeature‚ÉŠ®¬‚µ‚Äo‚Ä‚­‚é()
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