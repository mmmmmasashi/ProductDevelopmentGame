using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class BugFix
    {
        private readonly string _id;

        public BugFix(string id)
        {
            this._id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is BugFix fix &&
                   _id == fix._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }
}
