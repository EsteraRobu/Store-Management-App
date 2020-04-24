using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Management_App.Factory;
using Store_Management_App.Model;
using Store_Management_App.Payment;

namespace Store_Management_App.Account
{
    public class AccountProtected : IAccount
    {
        public List<Product> Products { get; set; }

        public AccountProtected()
        {
            Products = new List<Product>();
        }

        public void Buy(Product product)
        {
            Products.Add(product);
        }

        public void Pay(PaymentTerminal paymentTerminal)
        {
            Products.Clear();
            PayNotify(paymentTerminal);
            
        }

        public void PayNotify(PaymentTerminal paymentTerminal) {
            if (paymentTerminal == null) throw new ArgumentNullException(nameof(paymentTerminal));
            paymentTerminal.PaymentEvent += OnPayment;
        }

        private void OnPayment(object paymentTerminal, Payment.Payment payment) {
            Console.WriteLine($"You pay {payment.ValueToPay}");
        }

        public void DisplayTotalPrice()
        {
            double sum = 0;
            foreach (var product in Products)
                sum += product.Price;
            Console.WriteLine("Total price: " + sum);
        }
    }
}
