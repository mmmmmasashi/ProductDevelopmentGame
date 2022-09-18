using ProductDevDomainLib.Item;
using ProductDevDomainLib.Val;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Task
{
    internal class BugFixTask : ITask
    {
        private BugFixRequest bugFixRequest;
        private Action<BugFix> outputAction;
        public bool IsCompleted { get => VolumeNeeded.Value == 0; }
        public DevVolume VolumeNeeded { get; private set; }

        public BugFixTask(BugFixRequest bugFixRequest, Action<BugFix> outputAction)
        {
            this.bugFixRequest = bugFixRequest;
            this.outputAction = outputAction;
            VolumeNeeded = bugFixRequest.Volume;
        }

        public void WorkOn(DevVolume volumeToConsume)
        {
            if (VolumeNeeded.Value < volumeToConsume.Value) throw new ArgumentException();
            VolumeNeeded = VolumeNeeded.Minus(volumeToConsume);
            if (IsCompleted) outputAction(new BugFix(bugFixRequest.Id));
        }
    }
}
