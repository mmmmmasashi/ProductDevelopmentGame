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

        public bool IsCompleted { get => VolumeNeeded.Value == 0; }

        public DevVolume VolumeNeeded { get; private set; }

        public FeatureDevTask(FeatureRequest featureRequest, Action<Feature> outputAction)
        {
            this.featureRequest = featureRequest;
            this.outputAction = outputAction;
            this.VolumeNeeded = featureRequest.StoryPoint;
        }

        public void WorkOn(DevVolume volumeToConsume)
        {
            if (VolumeNeeded.Value < volumeToConsume.Value) throw new ArgumentException();
            VolumeNeeded = VolumeNeeded.Minus(volumeToConsume);
            if (IsCompleted) outputAction(new Feature(featureRequest.Id));
        }
    }
}
