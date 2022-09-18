using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class BugFixRequest
    {
        private readonly string _id;//対応するバグのID

        public BugFixRequest(string id)
        {
            this._id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is BugFixRequest request &&
                   _id == request._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }
}
