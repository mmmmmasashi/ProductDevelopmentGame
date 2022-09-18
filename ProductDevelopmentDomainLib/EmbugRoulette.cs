using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class EmbugRoulette
    {
        private readonly Rate _errorRate;
        private readonly Random _random;

        public EmbugRoulette(Rate errorRate)
        {
            this._errorRate = errorRate;
            this._random = new Random();
        }

        internal bool IsEmbugged()
        {
            return _random.NextDouble() <= _errorRate.Value;
        }
    }
}
