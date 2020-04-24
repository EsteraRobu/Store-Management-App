using Store_Management_App.CashRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Payment {
    public class PaymentTerminal {

        private Payment payment;
        public event EventHandler<Payment> PaymentEvent;

        public void Pay(Cashier cashier) {
            Console.WriteLine($"Your change is {payment.Pay(cashier)}");
            PaymentEvent?.Invoke(this, Payment);
        }

        public PaymentTerminal(Payment payment) {
            Payment = payment ?? throw new ArgumentNullException(nameof(payment));
        }

        public Payment Payment {
            get => payment;
            set {
                payment = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
