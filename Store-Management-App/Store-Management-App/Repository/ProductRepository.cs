using Store_Management_App.Decorators;
using Store_Management_App.Factory;
using Store_Management_App.Factory.Hardware;
using Store_Management_App.Factory.Software;
using Store_Management_App.Payment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Management_App.Repository
{
    public class ProductRepository
    {
        private List<Product> products;

        private static ProductRepository instance = null;
        private static readonly object padlock = new object();

        private ProductRepository()
        {
            IProvider simpleProvider = new SimpleProvider();
            simpleProvider.Assemble("PC Garage");

            products = new List<Product>{
                new MonitorsFactory().GetProduct("Dell", 3000, 10, new HardwareDecorator(simpleProvider)),
                new MonitorsFactory().GetProduct("Samsung", 2000, 5, new HardwareDecorator(simpleProvider)),
                new MonitorsFactory().GetProduct("ASUS", 4000, 20, new HardwareDecorator(simpleProvider)),
                new PcComponentFactory().GetProduct("Placa video Asus", 800, 50, new HardwareDecorator(simpleProvider)),
                new PcComponentFactory().GetProduct("Placa de baza ASUS", 1000, 20, new HardwareDecorator(simpleProvider)),
                new PcComponentFactory().GetProduct("Sursa Thermaltake", 250, 25, new HardwareDecorator(simpleProvider)),
                new PcPeripheralsFactory().GetProduct("Mouse Logitech", 150, 60, new HardwareDecorator(simpleProvider)),
                new PcPeripheralsFactory().GetProduct("Tastatura Razer", 650, 60, new HardwareDecorator(simpleProvider)),
                new PcPeripheralsFactory().GetProduct("Casti Trust", 210, 60, new HardwareDecorator(simpleProvider)),
                new AntivirusFactory().GetProduct("Kaspersky", 100, 50, new SoftwareDecorator(simpleProvider)),
                new AntivirusFactory().GetProduct("Bitdefender", 250, 50, new SoftwareDecorator(simpleProvider)),
                new AntivirusFactory().GetProduct("Eset", 180, 50, new SoftwareDecorator(simpleProvider)),
                new DesktopApplicationsFactory().GetProduct("Microsoft Office", 400, 30, new SoftwareDecorator(simpleProvider)),
                new DesktopApplicationsFactory().GetProduct("Autodesk, AutoCAD", 2800, 10, new SoftwareDecorator(simpleProvider)),
                new OperatingSystemFactory().GetProduct("Microsoft Windows 10", 800, 20, new SoftwareDecorator(simpleProvider)),
                new OperatingSystemFactory().GetProduct("Microsoft GGK Windows7 Pro", 1000, 10, new SoftwareDecorator(simpleProvider)),
            };
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

        public List<Product> GetAvailableProducts() => products.FindAll(product => product.Quantity > 0);

        public Product GetProduct(string name)
        {
            return products.FirstOrDefault(product => product.Name.ToUpper().Equals(name.ToUpper()));
        }

        public void UpdateProductPrice(string name, double price)
        {
            var product = products.FirstOrDefault(prod => prod.Name.ToUpper() == name.ToUpper());
            if (price > 0)
            {
                product.Price = price;
            }
        }

        public void UpdateProductQuantity(string name, int quantity)
        {
            var product = products.FirstOrDefault(prod => prod.Name.ToUpper() == name.ToUpper());
            if (quantity > 0)
            {
                product.Quantity -= quantity;
            }
        }
    }
}
