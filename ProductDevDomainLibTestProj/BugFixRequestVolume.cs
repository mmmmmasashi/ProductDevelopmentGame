using ProductDevDomainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductDevDomainLibTestProj
{
    public class BugFixRequestVolume
    {
        [Fact]
        public void デフォルトの対応工数は1()
        {
            var fixRequest = new BugFixRequest("ID1");
            Assert.Equal(new DevVolume(1), fixRequest.Volume);
        }

        [Fact]
        public void 対応工数は設定可能()
        {
            var fixRequest = new BugFixRequest("ID1", new DevVolume(3));
            Assert.Equal(new DevVolume(3), fixRequest.Volume);
        }

    }
}
