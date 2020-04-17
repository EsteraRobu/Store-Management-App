using Store_Management_App.Factory;
using Store_Management_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Account
{
    class SafeAccountProxy
    {
        public User user { get; set; }
        public IAccount RealSubject { get; set; }

        public SafeAccountProxy()
        {
            user.Username = "username";
            user.Password = "password";
        }

        public bool Activate(string username, string password)
        {
            if (username.Equals(user.Username) && password.Equals(user.Password))
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

        public void Pay()
        {
            if (RealSubject is AccountProtected)
                RealSubject.Pay();
        }

        public void DisplayTotalPrice()
        {
            if (RealSubject is AccountProtected)
                RealSubject.DisplayTotalPrice();
        }

    }
}
