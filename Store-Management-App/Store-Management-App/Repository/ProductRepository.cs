using Store_Management_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Repository
{
    class ProductRepository
    {
        private List<Product> products = new List<Product>
        {
            new Product(1, "Product1", 1200, 10),
            new Product(2, "Product2", 1200, 10),
            new Product(3, "Product3", 1200, 10),
            new Product(4, "Product4", 1200, 10)
        };


        private static ProductRepository instance = null;
        private static readonly object padlock = new object();

        private ProductRepository()
        {
            
        }

        public static ProductRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ProductRepository();
                    }
                    return instance;
                }
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts() => products;
        
        public Product GetProduct(string name) => products.First(product => product.Name == name);

        public void UpdateProductPrice(string name, double price)
        {
            var product = products.First(prod => prod.Name == name);
            if(price > 0)
            {
                product.Price = price;
            }
        }

        public void UpdateProductQuantity(string name, int quantity)
        {
            var product = products.First(prod => prod.Name == name);
            if (quantity > 0)
            {
                product.Quantity = quantity;
            }
        }
    }
}
