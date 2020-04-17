using Store_Management_App.Decorators;

namespace Store_Management_App.Factory.Hardware {
    class PcPeripheralsFactory : ProductFactory {
        public override Product GetProduct(string name, double price, int quantity, IProvider provider) {
            LastId++;
            return new Hardware(LastId, name, price, quantity, provider);
        }
    }
}
