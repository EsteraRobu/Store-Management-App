using Store_Management_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Account
{
    interface IAccount
    {
        void Buy(Product product);
        void Pay();
        void DisplayTotalPrice();
    }
}
