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

        public void Buy(string productName, int quantity)
        {
            if (RealSubject is AccountProtected)
                RealSubject.Buy(productName, quantity);
        }

        public void Pay(Payment.Payment payment, List<double> payedMoney, List<double> coinMoney)
        {
            if (RealSubject is AccountProtected)
                RealSubject.Pay(payment, payedMoney, coinMoney);
        }

        public double TotalValueToPay()
        {
            if (RealSubject is AccountProtected)
                return RealSubject.TotalValueToPay();
            return 0;
        }

        public void PrintPurchasedProducts()
        {
            if (RealSubject is AccountProtected)
                RealSubject.GetProducts().ForEach(product => Console.WriteLine(product.ToString()));
        }
    }
}
