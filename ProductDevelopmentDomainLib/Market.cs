using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class Market
    {
        private Product _productLatest;//リリース中のProduct

        internal void Release(Product product)
        {
            _productLatest = product;
        }

        internal IEnumerable<BugFixRequest> SpendTime()
        {
            return _productLatest.Use();
        }
    }
}
