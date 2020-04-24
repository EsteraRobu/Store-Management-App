﻿using Store_Management_App.Factory;
using Store_Management_App.Model;
using Store_Management_App.Payment;
using Store_Management_App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Account
{
    public class SafeAccountProxy
    {
        public User user { get; set; }
        public IAccount RealSubject { get; set; }

        public SafeAccountProxy()
        {
        }

        public bool Activate(string username, string password)
        {
            if (UserRepository.Instance.FindUser(username, password))
            {
                RealSubject = new AccountProtected();
                return true;
            }
            return false;
        }

        public void Buy(Product product)
        {
            if (RealSubject is AccountProtected)
                RealSubject.Buy(product);
        }

        public void Pay(PaymentTerminal paymentTerminal)
        {
            if (RealSubject is AccountProtected)
                RealSubject.Pay(paymentTerminal);
        }

        public void DisplayTotalPrice()
        {
            if (RealSubject is AccountProtected)
                RealSubject.DisplayTotalPrice();
        }

    }
}
