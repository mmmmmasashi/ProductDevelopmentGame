using ProductDevDomainLib.Val;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Item
{
    /// <summary>
    /// 機能の要求(未実装)
    /// </summary>
    internal class FeatureRequest
    {
        public DevVolume StoryPoint { get; }

        public string Id { get; }

        public FeatureRequest(string id, DevVolume? storyPoint = null)
        {
            Id = id;
            StoryPoint = storyPoint ?? new DevVolume(1);
        }

        internal Feature Done()
        {
            return new Feature(Id);
        }

        internal bool CanBeDone(DevVolume progress)
        {
            return StoryPoint.Value <= progress.Value;
        }

        internal Bug CreateBug()
        {
            return new Bug(Id);
        }
    }
}
