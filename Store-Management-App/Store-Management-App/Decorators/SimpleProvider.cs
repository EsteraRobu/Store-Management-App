using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
    class SimpleProvider:IProvider
    {
        public string Name { get; set; }
        public double TransportationPrice { get; set; }
        public ETypeProvider ProviderType { get; set; }
        public SimpleProvider()
        {
            ProviderType = ETypeProvider.SIMPLE;
            SetTransportationPrice();
        }
        public void Assemble(string name)
        {
            this.Name = name;
        }

        public void SetTransportationPrice()
        {
            TransportationPrice = 10;
        }

        public override string ToString()
        {
            return $"{TransportationPrice}";
        }
    }
}
