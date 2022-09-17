using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    /// <summary>
    /// 機能の要求(未実装)
    /// </summary>
    internal class FeatureRequest
    {
        public Progress StoryPoint { get; }

        public string Id { get; }

        public FeatureRequest(string id, Progress? storyPoint = null)
        {
            this.Id = id;
            this.StoryPoint = storyPoint ?? new Progress(1);
        }

        internal Feature Done()
        {
            return new Feature(this.Id);
        }
    }
}
