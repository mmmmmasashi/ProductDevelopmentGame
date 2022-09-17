using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    /// <summary>
    /// 開発チーム
    /// </summary>
    internal class DevTeam
    {
        private Queue<FeatureRequest> _featureRequests;
        private readonly Progress _velocity;
        private readonly Rate _errorRate;

        public DevTeam(Progress? velocity = null, Rate? errorRate = null)
        {
            _velocity = velocity ?? new Progress(1.0M);
            _errorRate = errorRate ?? new Rate(0);
            _featureRequests = new Queue<FeatureRequest>();
        }

        internal Output Work()
        {
            var output = new Output();

            FeatureRequest request = _featureRequests.Dequeue();
            Feature feature = request.Done();
            output.Add(feature);

            return output;
        }

        internal void RequestFeature(FeatureRequest featureRequest)
        {
            _featureRequests.Enqueue(featureRequest);
        }
    }
}
