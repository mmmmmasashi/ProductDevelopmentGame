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
        private readonly double _velocity;
        private readonly double _errorRate;

        public DevTeam(double velocity, double errorRate)
        {
            _velocity = velocity;
            _errorRate = errorRate;
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
