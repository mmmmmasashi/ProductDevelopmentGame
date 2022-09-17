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
        public string Id { get; }

        public FeatureRequest(string id)
        {
            this.Id = id;
        }

        internal Feature Done()
        {
            return new Feature(this.Id);
        }
    }
}
