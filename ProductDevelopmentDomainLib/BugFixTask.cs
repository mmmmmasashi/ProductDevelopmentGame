using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class BugFixTask : ITask
    {
        private BugFixRequest bugFixRequest;
        private Action<BugFix> outputAction;
        private DevVolume _volumeNeededToComplete;
        public BugFixTask(BugFixRequest bugFixRequest, Action<BugFix> outputAction)
        {
            this.bugFixRequest = bugFixRequest;
            this.outputAction = outputAction;
            _volumeNeededToComplete = bugFixRequest.Volume;

        }

        public bool IsCompleted { get; private set; } = false;

        public DevVolume WorkOn(DevVolume volumeCanConsume)
        {
            //TODO:FeatureRequestにInterfaceを実装してBugFixと一部共通化できる？
            if (_volumeNeededToComplete.Value <= volumeCanConsume.Value)
            {
                //TODO:不具合追加
                outputAction(new BugFix(bugFixRequest.Id));
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
