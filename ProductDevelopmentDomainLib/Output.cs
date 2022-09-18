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

        private List<Bug> bugs;
        public List<Bug> Bugs { get => bugs; }

        public Output(List<Feature>? features = null,  List<Bug>? bugs = null)
        {
            this.features = features ?? new List<Feature>();
            this.bugs = bugs ?? new List<Bug>();
        }

        internal void Add(Feature feature)
        {
            features.Add(feature);
        }

        internal void Add(Bug bug)
        {
            bugs.Add(bug);
        }

        public override bool Equals(object? obj)
        {
            return obj is Output output &&
                this.Features.Count() == output.Features.Count() &&
                this.Bugs.Count() == output.Bugs.Count() &&
                Enumerable.Range(0, this.Features.Count()).All(idx => this.Features[idx].Equals(output.Features[idx])) &&
                Enumerable.Range(0, this.Bugs.Count()).All(idx => this.Bugs[idx].Equals(output.Bugs[idx]));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Features, Bugs);
        }
    }
}
