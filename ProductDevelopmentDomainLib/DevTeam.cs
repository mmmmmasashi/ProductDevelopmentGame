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

        private Progress _progressLeft;//前回消費し切れていない進捗

        public DevTeam(Progress? velocity = null, Rate? errorRate = null)
        {
            _velocity = velocity ?? new Progress(1.0M);
            _errorRate = errorRate ?? new Rate(0);
            _featureRequests = new Queue<FeatureRequest>();
            _progressLeft = new Progress(0);
        }

        internal Output Work()
        {
            var output = new Output();
            var progress = _velocity.Add(_progressLeft);

            while (_featureRequests.Any())
            {
                FeatureRequest request = _featureRequests.Peek();//削除してない点に注意
                if (request.CanBeDone(progress))
                {
                    _featureRequests.Dequeue();
                    output.Add(request.Done());
                    progress = progress.Minus(request.StoryPoint);
                }
                else
                {
                    _progressLeft = progress;
                    break;
                }
            }

            return output;
        }

        internal void RequestFeature(FeatureRequest featureRequest)
        {
            _featureRequests.Enqueue(featureRequest);
        }
    }
}
