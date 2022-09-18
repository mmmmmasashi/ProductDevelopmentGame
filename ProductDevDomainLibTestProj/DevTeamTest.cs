using ProductDevDomainLib;
using System;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class DevTeamTest
    {
        [Fact]
        public void Velocity1で1単位時間仕事をするとFeatureRequestがFeatureに完成して出てくる()
        {
            var team = new DevTeam(errorRate: new Rate(0));

            team.RequestFeature(new FeatureRequest("SAMPLE_ID"));

            Output output = team.Work();

            Assert.Single(output.Features);
            Assert.Equal(new Feature("SAMPLE_ID"), output.Features[0]);
        }

        [Fact]
        public void Velocity3で1単位時間仕事をすると3Point分のアウトプットを出してくる()
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
        public void ベロシティが小数点の時に蓄積されること()
        {
            var team = new DevTeam(velocity: new DevVolume(0.7M), errorRate: new Rate(0));

            team.RequestFeature(new FeatureRequest("ID1"));
            team.RequestFeature(new FeatureRequest("ID2"));
            team.RequestFeature(new FeatureRequest("ID3"));
            team.RequestFeature(new FeatureRequest("ID4", new DevVolume(0.5M)));

            var features1 = team.Work().Features;
            Assert.Empty(features1);//残0.7

            var features2 = team.Work().Features;
            Assert.Equal(new Feature("ID1"), features2[0]);//1.4 -> 残0.4

            var features3 = team.Work().Features;
            Assert.Equal(new Feature("ID2"), features3[0]);//0.4+0.7=1.1 -> 残0.1

            var features4 = team.Work().Features;
            Assert.Empty(features4);//0.1 + 0.7 = 0.8

            var features5 = team.Work().Features;
            Assert.Equal(2, features5.Count);//0.8 + 0.7 = 1.5 ここでID4は0.5なので、丁度こなせるはず
            Assert.Equal(new Feature("ID3"), features5[0]);
            Assert.Equal(new Feature("ID4"), features5[1]);

        }

        [Fact]
        public void エラー発生率が100Percentの時は機能実装完了と同時にバグが生まれる()
        {
            var terribleTeam = new DevTeam(velocity: new DevVolume(1), errorRate: new Rate(1));
            terribleTeam.RequestFeature(new FeatureRequest("ID1"));

            var output = terribleTeam.Work();

            var expected = new Output();
            expected.Add(new Feature("ID1"));
            expected.Add(new Bug("ID1"));

            Assert.Equal(expected, output);
        }
    }
}