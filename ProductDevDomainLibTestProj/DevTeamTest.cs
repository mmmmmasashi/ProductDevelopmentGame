using ProductDevDomainLib;
using System;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class DevTeamTest_Perfect
    {
        private DevTeam team;

        public DevTeamTest_Perfect()
        {
            team = new DevTeam(errorRate: new Rate(0));
        }

        [Fact]
        public void Velocity1��1�P�ʎ��Ԏd���������FeatureRequest��Feature�Ɋ������ďo�Ă���()
        {
            team.RequestFeature(new FeatureRequest("SAMPLE_ID"));

            Output output = team.Work();

            Assert.Single(output.Features);
            Assert.Equal(new Feature("SAMPLE_ID"), output.Features[0]);
        }
    }
    public class DevTeamTest_Perfect_Velocity3
    {
        private DevTeam team;

        public DevTeamTest_Perfect_Velocity3()
        {
            team = new DevTeam(velocity: new DevVolume(3), errorRate: new Rate(0));
        }

        [Fact]
        public void Velocity3��1�P�ʎ��Ԏd���������3Point���̃A�E�g�v�b�g���o���Ă���()
        {
            team.RequestFeature(new FeatureRequest("ID1"));
            team.RequestFeature(new FeatureRequest("ID2"));
            team.RequestFeature(new FeatureRequest("ID3"));
            team.RequestFeature(new FeatureRequest("ID4"));

            var output = team.Work();

            var expected = new Output();
            expected.Add(new Feature("ID1"));
            expected.Add(new Feature("ID2"));
            expected.Add(new Feature("ID3"));

            Assert.Equal(expected, output);
        }
    }

    public class DevTeamTest_Perfect_Velocity�����_
    {
        private DevTeam team;
        public DevTeamTest_Perfect_Velocity�����_()
        {
            team = new DevTeam(velocity: new DevVolume(0.7M), errorRate: new Rate(0));
        }

        [Fact]
        public void �x���V�e�B�������_�̎��ɒ~�ς���邱��()
        {

            team.RequestFeature(new FeatureRequest("ID1"));
            team.RequestFeature(new FeatureRequest("ID2"));
            team.RequestFeature(new FeatureRequest("ID3"));
            team.RequestFeature(new FeatureRequest("ID4", new DevVolume(0.5M)));

            var features1 = team.Work().Features;
            Assert.Empty(features1);//�c0.7

            var features2 = team.Work().Features;
            Assert.Equal(new Feature("ID1"), features2[0]);//1.4 -> �c0.4

            var features3 = team.Work().Features;
            Assert.Equal(new Feature("ID2"), features3[0]);//0.4+0.7=1.1 -> �c0.1

            var features4 = team.Work().Features;
            Assert.Empty(features4);//0.1 + 0.7 = 0.8

            var output5 = team.Work();
            
            var output = new Output(new List<Feature>() { new Feature("ID3") , new Feature("ID4") });
            Assert.Equal(output, output5);
        }
    }

    public class DevTeamTest_�G���o�O��100Percent�`�[��
    {
        DevTeam terribleTeam;

        public DevTeamTest_�G���o�O��100Percent�`�[��()
        {
            terribleTeam = new DevTeam(velocity: new DevVolume(1), errorRate: new Rate(1));
        }

        [Fact]
        public void �G���[��������100Percent�̎��͋@�\���������Ɠ����Ƀo�O�����܂��()
        {
            terribleTeam.RequestFeature(new FeatureRequest("ID1"));

            var output = terribleTeam.Work();

            var expected = new Output(new List<Feature>() { new Feature("ID1") }, new List<Bug>() { new Bug("ID1") });
            Assert.Equal(expected, output);
        }
    }
}