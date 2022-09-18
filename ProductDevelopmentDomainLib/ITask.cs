using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal interface ITask
    {
        bool IsCompleted { get; }
        DevVolume WorkOn(DevVolume volumeCanConsume);//消費可能な最大Volumeを入力し、実際に消費されたVolumeをReturnする
    }
}
