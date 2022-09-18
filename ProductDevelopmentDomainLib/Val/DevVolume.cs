using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Val
{
    /// <summary>
    /// 開発ボリューム
    /// </summary>
    /// <remarks>
    /// ストーリーポイント, ベロシティがこれを単位とする
    /// </remarks>
    internal class DevVolume
    {
        public decimal Value { get; }

        public DevVolume(decimal value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is DevVolume progress &&
                   Value == progress.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        internal DevVolume Add(DevVolume progressAdded)
        {
            return new DevVolume(Value + progressAdded.Value);
        }

        internal DevVolume Minus(DevVolume progressSub)
        {
            return new DevVolume(Value - progressSub.Value);
        }

        internal DevVolume Copy()
        {
            return new DevVolume(Value);
        }
    }
}
