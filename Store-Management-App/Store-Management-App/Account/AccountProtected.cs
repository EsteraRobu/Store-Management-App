using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Management_App.Factory;
using Store_Management_App.Model;

namespace Store_Management_App.Account
{
    class AccountProtected : IAccount
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

        public void Pay()
        {
            Products.Clear();
            //Add money for user and recalculate them
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
