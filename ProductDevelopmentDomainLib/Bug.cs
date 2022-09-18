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

        public Bug(string id)
        {
            this._id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Bug bug &&
                   _id == bug._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }
}
