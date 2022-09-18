using ProductDevDomainLib;
using ProductDevDomainLib.Item;
using ProductDevDomainLib.Val;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class BugTest
    {
        [Fact]
        public void Bugは単位時間あたりの発生確率を持つ()
        {
            var bug = new Bug("ID1", new Rate(0.01));
            Assert.Equal(new Rate(0.01), bug.EventProbability);
        }

        [Fact]
        public void Bugは修正必要工数を持つ_デフォルトは1()
        {
            var bug = new Bug("ID1");
            Assert.Equal(new DevVolume(1), bug.VolumeToFix);
        }

        [Fact]
        public void BugからBugFixRequestを生成でき_対応工数が引き継がれる()
        {
            var bug = new Bug("ID1", volumeToFix: new DevVolume(3));
            Assert.Equal(new BugFixRequest("ID1", new DevVolume(3)), bug.ToFixRequest());
        }
    }
}
