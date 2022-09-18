﻿using System;
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

        private ITask? _wip = null;
        private EventRoulette _embugRoulette;
        private Queue<ITask> _taskQueue;

        private List<Feature> _featureBuffer;
        private List<BugFix> _bugFixBuffer;
        private List<Bug> _bugBuffer;

        private readonly DevVolume _velocity;

        public DevTeam(DevVolume? velocity = null, Rate? errorRate = null)
        {
            _velocity = velocity ?? new DevVolume(1.0M);
            errorRate = errorRate ?? new Rate(0);
            _embugRoulette = new EventRoulette(errorRate);

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
            //TODO:自然に考えると、仕掛かり品的な概念があって、途中までこなしたとするべき？
            //今はDevTeamが「余剰ポイント」として持っていてやや不自然。
            while (_wip != null || _taskQueue.Any())
            {
                if (devVolume.Value == 0) break;
                ITask targetTask = _wip ?? _taskQueue.Dequeue();
                
                var consumedVolume = targetTask.WorkOn(devVolume);
                devVolume = devVolume.Minus(consumedVolume);

                if (targetTask.IsCompleted)
                {
                    _wip = null;

                    if (_embugRoulette.IsEmbugged()) _bugBuffer.Add(new Bug());
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
