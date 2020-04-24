using Store_Management_App.Account;
using Store_Management_App.CashRegister;
using Store_Management_App.Factory;
using Store_Management_App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Payment {
    public class Payment {
        private double valueReceived;
        private double valueToPay;

        public Payment() {

        }

        public double ValueReceived {
            get => valueReceived;
            set {
                if (value < 0.0f) throw new ArgumentOutOfRangeException("Price must be assigned a value bigger than 0.", nameof(value));
                valueReceived = value;
            }
        }

        public double ValueToPay {
            get => valueToPay;
            set {
                if (value < 0.0f) throw new ArgumentOutOfRangeException("Price must be assigned a value bigger than 0.", nameof(value));
                valueToPay = value;
            }
        }

        public Payment(double valueReceived, double valueToPay) {
            if (valueReceived < 0) throw new ArgumentOutOfRangeException(nameof(valueReceived));
            if (valueToPay < 0) throw new ArgumentOutOfRangeException(nameof(valueToPay));

            ValueReceived = valueReceived;
            ValueToPay = valueToPay;
        }

        public void ValueReceivedMethod(double value) {
            if (value >= ValueToPay) {
                ValueReceived = value;
            }
        }

        public bool VerifyPayment() {
            return ValueReceived <= ValueToPay;
        }

        public double Pay() {
            if (ValueReceived >= ValueToPay) {
                var change = GetChange();
                return change;
            }
            return 0;
        }

        public double GetChange() {
            Console.WriteLine("Successful transaction.");
            return ValueReceived - ValueToPay;
        }
    }
}
