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

        [Fact]
        public void Velocity3��1�P�ʎ��Ԏd���������3Point���̃A�E�g�v�b�g���o���Ă���()
        {
            var team = new DevTeam(velocity: new DevVolume(3), errorRate: new Rate(0));
            
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

        [Fact]
        public void �x���V�e�B�������_�̎��ɒ~�ς���邱��()
        {
            var team = new DevTeam(velocity: new DevVolume(0.7M), errorRate: new Rate(0));

            team.RequestFeature(new FeatureRequest("ID1"));
            team.RequestFeature(new FeatureRequest("ID2"));
            team.RequestFeature(new FeatureRequest("ID3"));
            team.RequestFeature(new FeatureRequest("ID4"));

            var features1 = team.Work().Features;
            Assert.Empty(features1);//�c0.7

            var features2 = team.Work().Features;
            Assert.Equal(new Feature("ID1"), features2[0]);//1.4 -> �c0.4

            var features3 = team.Work().Features;
            Assert.Equal(new Feature("ID2"), features3[0]);//0.4+0.7=1.1 -> �c0.1

            var features4 = team.Work().Features;
            Assert.Empty(features4);//0.1 + 0.7 = 0.8
        }
    }
}