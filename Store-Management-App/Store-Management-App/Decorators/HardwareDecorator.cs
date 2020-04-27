using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
    class HardwareDecorator : ProviderDecorator
    {
        public HardwareDecorator(IProvider provider) : base(provider)
        {
            provider.ProviderType = ETypeProvider.HARDWARE;
            ProviderType = ETypeProvider.HARDWARE;
            SetTransportationPrice();
        }

        public override sealed void SetTransportationPrice()
        {
            decoratedProvider.TransportationPrice = 20;
            TransportationPrice = 20;
        }
    }
}
