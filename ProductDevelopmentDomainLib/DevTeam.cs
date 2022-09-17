using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
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
            FeatureRequest request = _featureRequests.Dequeue();
            Feature feature = request.Done();
            return new Output(new List<Feature>() { feature });
        }

        internal void RequestFeature(FeatureRequest featureRequest)
        {
            _featureRequests.Enqueue(featureRequest);
        }
    }
}
