using Store_Management_App.Factory;
using Store_Management_App.Model;
using Store_Management_App.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Account
{
    public interface IAccount
    {
        void Buy(Product product);
        void Pay(PaymentTerminal paymentTerminal);
        void DisplayTotalPrice();
    }
}
