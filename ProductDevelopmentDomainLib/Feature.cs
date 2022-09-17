using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    /// <summary>
    /// 完成した機能
    /// </summary>
    internal class Feature
    {
        private string _id;

        public Feature(string id)
        {
            this._id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Feature feature &&
                   _id == feature._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }
}
