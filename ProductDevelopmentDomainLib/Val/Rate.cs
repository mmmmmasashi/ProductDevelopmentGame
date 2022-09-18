using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Val
{
    internal class Rate
    {
        private readonly double _value;
        public double Value { get => _value; }

        public Rate(double value)
        {
            if (value < 0 || 1 < value) throw new ArgumentOutOfRangeException();
            _value = value;
        }


        public override bool Equals(object? obj)
        {
            return obj is Rate rate &&
                   _value == rate._value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }
    }
}
