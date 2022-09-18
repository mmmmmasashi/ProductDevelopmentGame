using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class Bug
    {
        private readonly string _id;
        public Rate EventProbability { get; }//単位時間あたりのバグの市場発生確率

        public Bug(string id, Rate? rate = null)
        {
            this.EventProbability = rate ?? new Rate(0.01);
            this._id = id;
        }


        public override bool Equals(object? obj)
        {
            return obj is Bug bug &&
                   _id == bug._id;
        }

        internal BugFixRequest ToFixRequest()
        {
            return new BugFixRequest(_id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }
}
