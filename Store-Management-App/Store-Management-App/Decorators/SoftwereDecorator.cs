using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
    class SoftwereDecorator : ProviderDecorator
    {
        public SoftwereDecorator(IProvider decoratedProvider) : base(decoratedProvider)
        {
            decoratedProvider.ProviderType = ETypeProvider.SOFTWERE;
            SetTransportationPrice();
        }

        public override void SetTransportationPrice()
        {
            decoratedProvider.TransportationPrice += 0.5;
        }
    }
}
