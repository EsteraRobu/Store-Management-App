using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
    public abstract class ProviderDecorator : IProvider
    {
        protected IProvider decoratedProvider;

        public string Name { get; set ; }
        public double TransportationPrice { get; set; }
        public ETypeProvider ProviderType { get; set; }

        public ProviderDecorator(IProvider decoratedProvider)
        {
            this.decoratedProvider = decoratedProvider;
        }
        public void Assemble(string name)
        {
            this.Name = name;
        }

        public abstract void SetTransportationPrice();

        public override string ToString()
        {
            return $"{decoratedProvider.TransportationPrice}";
        }
    }
}
