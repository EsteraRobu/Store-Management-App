using Store_Management_App.Decorators;

namespace Store_Management_App.Factory {
    public abstract class ProductFactory {
        public static int LastId { get; set; } = 0;
        public abstract Product GetProduct(string name, double price, int quantity, IProvider provider);
    }
}
