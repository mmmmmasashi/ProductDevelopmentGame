using Moq;
using ProductDevDomainLib.Item;
using ProductDevDomainLib.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDevDomainLib.Val;

namespace ProductDevDomainLib.Unit
{
    /// <summary>
    /// 開発チーム
    /// </summary>
    internal class DevTeam
    {

        private ITask? _wip = null;
        private EventRoulette _embugRoulette;
        private Queue<ITask> _taskQueue;

        private List<Feature> _featureBuffer;
        private List<BugFix> _bugFixBuffer;
        private List<Bug> _bugBuffer;
        private IIdFactory _idFactory;
        private readonly DevVolume _velocity;

        public DevTeam(DevVolume? velocity = null, Rate? errorRate = null, IIdFactory? idFactory = null)
        {
            _velocity = velocity ?? new DevVolume(1.0M);
            errorRate = errorRate ?? new Rate(0);
            _embugRoulette = new EventRoulette(errorRate);
            _idFactory = idFactory ?? new RandomIdFactory();

            _taskQueue = new Queue<ITask>();

            _featureBuffer = new List<Feature>();
            _bugFixBuffer = new List<BugFix>();
            _bugBuffer = new List<Bug>();
        }

        /// <summary>
        /// 単位時間だけ仕事をしてアウトプットを出す
        /// </summary>
        internal Output Work()
        {
            var output = new Output();
            var devVolume = _velocity.Copy();

            while (true)
            {
                if (_wip == null && !_taskQueue.Any()) break;
                if (devVolume.Value == 0) break;

                ITask targetTask = _wip ?? _taskQueue.Dequeue();

                bool canFinish = targetTask.VolumeNeeded.Value <= devVolume.Value;
                DevVolume volumeToConsume = canFinish ? targetTask.VolumeNeeded : devVolume;

                targetTask.WorkOn(volumeToConsume);
                devVolume = devVolume.Minus(volumeToConsume);

                if (targetTask.IsCompleted)
                {
                    _wip = null;
                    if (_embugRoulette.IsEmbugged()) _bugBuffer.Add(new Bug(_idFactory.Create()));
                }
                else
                {
                    _wip = targetTask;
                }
            }

            return ExportOutput();
        }

        private Output ExportOutput()
        {
            var output = new Output(new List<Feature>(_featureBuffer), new List<Bug>(_bugBuffer), new List<BugFix>(_bugFixBuffer));
            _featureBuffer.Clear();
            _bugFixBuffer.Clear();
            _bugBuffer.Clear();
            return output;
        }

        internal void RequestFeature(FeatureRequest featureRequest)
        {
            ITask featureTask = new FeatureDevTask(featureRequest, (feature) => _featureBuffer.Add(feature));
            _taskQueue.Enqueue(featureTask);
        }

        internal void RequestBugFix(BugFixRequest bugFixRequest)
        {
            ITask bugFixTask = new BugFixTask(bugFixRequest, (bugFix) => _bugFixBuffer.Add(bugFix));
            _taskQueue.Enqueue(bugFixTask);
        }
    }
}
