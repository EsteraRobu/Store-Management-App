using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
    class HardAndSoftDecorator : ProviderDecorator
    {
        public HardAndSoftDecorator(IProvider provider) : base(provider)
        {
            provider.ProviderType = ETypeProvider.HARD_AND_SOFT;
            ProviderType = ETypeProvider.HARD_AND_SOFT;
            SetTransportationPrice();
        }

        public override sealed void SetTransportationPrice()
        {
            decoratedProvider.TransportationPrice = 15;
            TransportationPrice = 15;
        }
    }
}
