using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDevDomainLib
{
    internal class Output
    {
        private List<Feature> features;
        public List<Feature> Features { get => features; }

        public Output(List<Feature> features)
        {
            this.features = features;
        }

    }
}
