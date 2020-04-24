using Store_Management_App.Decorators;

namespace Store_Management_App.Factory {
    public abstract class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; } = 0.0;
        public int Quantity { get; set; } = 0;
        public IProvider Provider { get; set; }

        public abstract EProductType Type();

        public Product () { }

        public Product(int id, string name, double price, int quantity, IProvider provider)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Provider = provider;
        }

        public override string ToString() {
            return $"{Name}, price: {Price}, quantity: {Quantity}, provider: {Provider.Name}, type: {Type()}"; 
        }
    }
}
