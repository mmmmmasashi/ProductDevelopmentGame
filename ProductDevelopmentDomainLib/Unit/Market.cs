using ProductDevDomainLib.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Unit
{
    internal class Market
    {
        private Product _productLatest;//リリース中のProduct

        public Market(Product product)
        {
            this._productLatest = product;
        }

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
