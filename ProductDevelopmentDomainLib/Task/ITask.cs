using ProductDevDomainLib.Val;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Task
{
    internal interface ITask
    {
        DevVolume VolumeNeeded { get; }
        bool IsCompleted { get; }
        void WorkOn(DevVolume volumeCanConsume);//消費可能な最大Volumeを入力し、実際に消費されたVolumeをReturnする
    }
}
