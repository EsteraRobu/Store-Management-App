using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
    class SoftwareDecorator : ProviderDecorator
    {
        public SoftwareDecorator(IProvider provider) : base(provider)
        {
            provider.ProviderType = ETypeProvider.SOFTWARE;
            ProviderType = ETypeProvider.SOFTWARE;
            SetTransportationPrice();
        }

        public override sealed void SetTransportationPrice()
        {
            decoratedProvider.TransportationPrice = 12;
            TransportationPrice = 12;
        }
    }
}
