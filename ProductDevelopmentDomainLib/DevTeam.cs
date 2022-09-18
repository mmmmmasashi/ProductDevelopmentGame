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
        private readonly DevVolume _velocity;
        private readonly EventRoulette _embugRoulette;

        private DevVolume _progressLeft;//前回消費し切れていない進捗

        public DevTeam(DevVolume? velocity = null, Rate? errorRate = null)
        {
            _velocity = velocity ?? new DevVolume(1.0M);
            _embugRoulette = new EventRoulette(errorRate ?? new Rate(0));
            _featureRequests = new Queue<FeatureRequest>();
            _progressLeft = new DevVolume(0);
        }

        /// <summary>
        /// 単位時間だけ仕事をしてアウトプットを出す
        /// </summary>
        internal Output Work()
        {
            var output = new Output();
            var progress = _velocity.Add(_progressLeft);

            //TODO:自然に考えると、仕掛かり品的な概念があって、途中までこなしたとするべき？
            //今はDevTeamが「余剰ポイント」として持っていてやや不自然。
            while (_featureRequests.Any())
            {
                FeatureRequest request = _featureRequests.Peek();//削除してない点に注意
                if (request.CanBeDone(progress))
                {
                    _featureRequests.Dequeue();

                    //機能と確率的にバグを出す
                    output.Add(request.Done());

                    if (_embugRoulette.IsEmbugged())
                    {
                        output.Add(request.CreateBug());
                    }

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
