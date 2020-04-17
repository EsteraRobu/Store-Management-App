using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Decorators
{
   public interface IProvider
    {
        string Name { get; set; }
        ETypeProvider ProviderType { get; set; }
        double TransportationPrice { get; set; }

        void SetTransportationPrice();
        void Assemble(string name);
    }
}
