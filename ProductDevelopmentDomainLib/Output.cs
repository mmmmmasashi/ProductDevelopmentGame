using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    /// <summary>
    /// 開発チームのアウトプット
    /// </summary>
    internal class Output
    {
        private List<Feature> features;
        public List<Feature> Features { get => features; }

        public Output()
        {
            features = new List<Feature>();
        }

        internal void Add(Feature feature)
        {
            features.Add(feature);
        }
    }
}
