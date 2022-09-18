using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class FeatureDevTask : ITask
    {
        private readonly FeatureRequest featureRequest;
        private readonly Action<Feature> outputAction;
        private DevVolume _volumeNeededToComplete;

        public FeatureDevTask(FeatureRequest featureRequest, Action<Feature> outputAction)
        {
            this.featureRequest = featureRequest;
            this.outputAction = outputAction;
            this._volumeNeededToComplete = featureRequest.StoryPoint;
        }

        public bool IsCompleted { get; private set; } = false;

        public DevVolume WorkOn(DevVolume volumeCanConsume)
        {
            //TODO:FeatureRequestにInterfaceを実装してBugFixと一部共通化できる？
            if (_volumeNeededToComplete.Value <= volumeCanConsume.Value)
            {
                //TODO:不具合追加
                outputAction(new Feature(featureRequest.Id));
                IsCompleted = true;
                return _volumeNeededToComplete;
            }
            else
            {
                _volumeNeededToComplete = _volumeNeededToComplete.Minus(volumeCanConsume);
                return volumeCanConsume;
            }
        }
    }
}
