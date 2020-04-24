using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Management_App.CashRegister;
using Store_Management_App.Factory;
using Store_Management_App.Model;
using Store_Management_App.Payment;
using Store_Management_App.Repository;

namespace Store_Management_App.Account {
    public class AccountProtected : IAccount {
        public List<Product> Products { get; set; }

        public AccountProtected() {
            Products = new List<Product>();
        }

        public void Buy(string name, int quantity) {
            Product product = ProductRepository.Instance.GetProduct(name);
            if (product == null) throw new ArgumentNullException("The product doesn`t exist");

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
            double sum = 0;
            foreach (var product in Products)
            {
                sum += (product.Quantity * product.Price);
            }

            Console.WriteLine("Total price: " + sum);

            return sum;
        }
    }
}
