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
        public decimal StoryPoint { get; }

        public string Id { get; }

        public FeatureRequest(string id, decimal storyPoint = 1.0M)
        {
            this.Id = id;
            this.StoryPoint = storyPoint;
        }

        internal Feature Done()
        {
            return new Feature(this.Id);
        }
    }
}
