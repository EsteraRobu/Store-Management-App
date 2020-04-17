using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
    class HardwereDecorator : ProviderDecorator
    {
        public HardwereDecorator(IProvider decoratedProvider) : base(decoratedProvider)
        {
            decoratedProvider.ProviderType = ETypeProvider.HARDWERE;
            SetTransportationPrice();
        }

        public override void SetTransportationPrice()
        {
            decoratedProvider.TransportationPrice +=40;
        }
    }
}
