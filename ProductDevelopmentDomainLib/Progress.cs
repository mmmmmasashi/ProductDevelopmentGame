using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    /// <summary>
    /// 進捗
    /// </summary>
    /// <remarks>
    /// 単位としてはPt。ストーリーポイント, ベロシティがこれを単位とする
    /// </remarks>
    internal class Progress
    {
        public decimal Value { get; }

        public Progress(decimal value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Progress progress &&
                   Value == progress.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        internal Progress Add(Progress progressAdded)
        {
            return new Progress(this.Value + progressAdded.Value);
        }

        internal Progress Minus(Progress progressSub)
        {
            return new Progress(this.Value - progressSub.Value);
        }
    }
}
