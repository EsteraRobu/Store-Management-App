using Store_Management_App.Account;
using Store_Management_App.CashRegister;
using Store_Management_App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Ordering {
    class Panel {

        private Payment.Payment payment;
        private SafeAccountProxy account;

        public Panel() {
            payment = new Payment.Payment();
            account = new SafeAccountProxy();

            Console.WriteLine("Type the username:");
            var username = Console.ReadLine();

            Console.WriteLine("Type the password:");
            var password = Console.ReadLine();

            if (account.Activate(username, password)) {
                Run();
            } else {
                Console.WriteLine("Wrong password or username");

            }
        }

        public void Run() {
            ProductRepository.Instance.GetAvailableProducts().ForEach(product => product.ToString());

            Console.WriteLine("\nPlease enter the name of product: ");
            string name;
            int quantity;

            name = Console.ReadLine();
            if (name == null) throw new ArgumentOutOfRangeException("Id Product must be bigger than 0.", nameof(name));

            Console.WriteLine("Please enter the quantity you want: ");
            quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity < 0) throw new ArgumentOutOfRangeException("You can`t choose a quantity smaller than 0.", nameof(quantity));

            Cashier cashier = new Cashier();

            while (payment.VerifyPayment()) {
                Console.WriteLine("\nPlease enter the option for payment you want: \n" +
                              "1. Cash\n " +
                              "2. Card\n " +
                              "3. Coin\n ");
                int userInput;
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput) {
                    case 1: {
                            Console.WriteLine("Please enter the cash: ");
                            double cash = Convert.ToInt32(Console.ReadLine());
                            cashier.CashIn(cash, EMoneyType.Paper);

                        }
                        break;
                    case 2: {
                            Console.WriteLine("Please enter the coins: ");
                            double coin = Convert.ToInt32(Console.ReadLine());
                            cashier.CashIn(coin, EMoneyType.Coin);

                        }
                        break;

                    case 3: {
                            Console.WriteLine("Please enter cash from card: ");
                            double cash = Convert.ToInt32(Console.ReadLine());
                            cashier.CashIn(cash, EMoneyType.Card);

                        }
                        break;
                    default:
                        break;
                }

                payment.ValueReceivedMethod(cashier.GetTotalCache());
            }

            payment.UserPayment(account);

            Console.WriteLine("You want something else?");
            String decision;
            decision = Console.ReadLine();
            switch (decision) {
                case "no":
                    break;
                case "yes":
                    Run();
                    break;
                default:
                    Console.WriteLine("Next time please enter yes / no.");
                    break;
            }

        }
    }
}
