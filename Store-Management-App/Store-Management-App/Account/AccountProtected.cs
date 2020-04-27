using System;
using System.Collections.Generic;
using Store_Management_App.Decorators;
using Store_Management_App.Factory;
using Store_Management_App.Payment;
using Store_Management_App.Repository;

namespace Store_Management_App.Account
{
    public class AccountProtected : IAccount {

        public Dictionary<ETypeProvider, double> providers = new Dictionary<ETypeProvider, double>();
        public List<Product> Products { get; set; }

        public AccountProtected() {
            Products = new List<Product>();
        }

        public void Buy(string name, int quantity) {
            Product product = ProductRepository.Instance.GetProduct(name);
            if (product == null) Console.WriteLine("The product doesn`t exist");
            else
            {
                if (product.Quantity >= quantity)
                {
                    ProductRepository.Instance.UpdateProductQuantity(name, quantity);
                }
                else
                {
                    Console.Error.Write($"Your quantity is bigger, we just have {product.Quantity} piece of {product.Name} \n");
                }

                product.Quantity = quantity;
                Products.Add(product);

                IProvider provider = product.Provider;

                if (!providers.ContainsKey(provider.ProviderType))
                {
                    providers.Add(provider.ProviderType, provider.TransportationPrice);
                }
            }
        }

        public void Pay(Payment.Payment payment, List<double> payedMoney, List<double> coinMoney) {
            Products.Clear();

            PaymentTerminal paymentTerminal = new PaymentTerminal(payment);
            PayNotify(paymentTerminal);
            paymentTerminal.Pay(payedMoney, coinMoney);
        }

        public void PayNotify(PaymentTerminal paymentTerminal) {
            if (paymentTerminal == null) throw new ArgumentNullException(nameof(paymentTerminal));
            paymentTerminal.PaymentEvent += OnPayment;
        }

        private void OnPayment(object paymentTerminal, Payment.Payment payment) {
            Console.WriteLine($"You pay {payment.ValueToPay}");
        }

        public double TotalValueToPay() {
            double productsSum = 0, transportationSum = 0;
            foreach (var product in Products)
            {
                productsSum += (product.Quantity * product.Price);
            }

            foreach (var providerTransportation in providers)
            {
                transportationSum += providerTransportation.Value;
            }

            Console.WriteLine("\nTotal price: " + productsSum);
            Console.WriteLine("Transportation price: " + transportationSum);

            return productsSum + transportationSum;
        }

        public List<Product> GetProducts() => Products;
    }
}
