using ProductDevDomainLib.Val;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    /// <summary>
    /// イベントの発生の抽選を行う
    /// </summary>
    internal class EventRoulette
    {
        private readonly Rate _probability;
        private readonly Random _random;

        public EventRoulette(Rate probability)
        {
            this._probability = probability;
            this._random = new Random();
        }

        internal bool IsEmbugged()
        {
            return _random.NextDouble() <= _probability.Value;
        }
    }
}
