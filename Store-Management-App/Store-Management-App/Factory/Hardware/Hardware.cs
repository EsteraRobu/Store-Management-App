using Store_Management_App.Decorators;

namespace Store_Management_App.Factory.Hardware {
    public class Hardware : Product {
        public Hardware(int id, string name, double price, int quantity, IProvider provider) 
            : base(id, name, price, quantity, provider) {
        }

        public override EProductType Type() {
            return EProductType.HARDWARE;
        }
    }
}
