using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Model
{
    class HardAndSoftDecorator : ProviderDecorator
    {
        public HardAndSoftDecorator(IProvider decoratedProvider) : base(decoratedProvider)
        {
            decoratedProvider.ProviderType = ETypeProvider.HARD_AND_SOFT;
            SetTransportationPrice();
        }

        public override void SetTransportationPrice()
        {
            decoratedProvider.TransportationPrice += 40.5;
        }
    }
}
