using ProductDevDomainLib.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib.Unit
{
    internal class Product
    {
        List<Bug> _bugList = new List<Bug>();
        internal void Add(Bug bug)
        {
            _bugList.Add(bug);
        }

        /// <summary>
        /// 単位時間分使って、バグの発生をシミュレートする
        /// </summary>
        internal IEnumerable<BugFixRequest> Use()
        {
            return _bugList.Where(bug => new EventRoulette(bug.EventProbability).IsEmbugged()).Select(bug => bug.ToFixRequest());
        }
    }
}
