using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Item
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
        public List<BugFix> BugFixes { get; }

        public Output(List<Feature>? features = null, List<Bug>? bugs = null, List<BugFix>? bugFixes = null)
        {
            this.features = features ?? new List<Feature>();
            this.bugs = bugs ?? new List<Bug>();
            BugFixes = bugFixes ?? new List<BugFix>();
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
                Features.Count() == output.Features.Count() &&
                Bugs.Count() == output.Bugs.Count() &&
                Enumerable.Range(0, Features.Count()).All(idx => Features[idx].Equals(output.Features[idx])) &&
                Enumerable.Range(0, Bugs.Count()).All(idx => Bugs[idx].Equals(output.Bugs[idx]));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Features, Bugs);
        }
    }
}
