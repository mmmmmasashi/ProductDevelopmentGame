using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Unit
{
    internal class RandomIdFactory : IIdFactory
    {
        public string Create()
        {
            Guid guidValue = Guid.NewGuid();
            return guidValue.ToString();
        }
    }
}
