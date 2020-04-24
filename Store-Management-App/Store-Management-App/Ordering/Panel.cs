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

            while(true)
            {
                Console.Write("Username:");
                var username = Console.ReadLine();

                Console.Write("Password:");
                var password = Console.ReadLine();

                if (account.Activate(username, password))
                {
                    VisualizeProducts();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong password or username! Please try again.");
                }
            }
            
        }

        public void VisualizeProducts()
        {
            ProductRepository.Instance.GetAvailableProducts().ForEach(product => Console.WriteLine(product.ToString()));

            Console.WriteLine("\nDo you want to buy something?(yes/no)");
            String decision;
            decision = Console.ReadLine();
            switch (decision)
            {
                case "no":
                    Console.WriteLine("Thank you for your time. Have a nice day!");
                    break;
                case "yes":
                    Run();
                    break;
                default:
                    Console.WriteLine("Next time please enter yes/no.");
                    break;
            }

        }

        public void Run()
        {
            ProductRepository.Instance.GetAvailableProducts().ForEach(product => Console.WriteLine(product.ToString()));

            Console.WriteLine("\nPlease enter the name product: ");
            string name;
            int quantity;

            name = Console.ReadLine();
            if (name == null) throw new ArgumentOutOfRangeException("Id Product must be bigger than 0.", nameof(name));

            Console.WriteLine("Please enter the quantity you want: ");
            quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity < 0) throw new ArgumentOutOfRangeException("You can`t choose a quantity smaller than 0.", nameof(quantity));

            account.Buy(name, quantity);

            Console.WriteLine("You want something else?(yes/no)");
            String decision;
            decision = Console.ReadLine();
            switch (decision) {
                case "no":
                    Payment();
                    break;
                case "yes":
                    Run();
                    break;
                default:
                    Console.WriteLine("Next time please enter yes/no.");
                    break;
            }
        }

        public void Payment() {
            Cashier cashier = Cashier.Instance;
            payment.ValueReceived = 0;
            payment.ValueToPay = account.TotalValueToPay();
            List<double> paperMoney = new List<double>();
            List<double> coinMoney = new List<double>();
            double payedValue = 0;

            while (payment.VerifyPayment()) {
                Console.WriteLine("You have to pay: " + (payment.ValueToPay - payedValue));
                Console.WriteLine("\nPlease enter the option for payment you want: \n" +
                              "1. Paper\n" +
                              "2. Coin\n" +
                              "3. Card\n");
                int userInput;
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput) {
                    case 1: {
                            Console.WriteLine("Please enter the banknote(1, 5, 10, 50, 100, 200, 500): ");
                            double paper = Convert.ToInt32(Console.ReadLine());
                            paperMoney.Add(paper);
                            payedValue += paper;
                        }
                        break;
                    case 2: {
                            Console.WriteLine("Please enter the coins(0.01, 0.05, 0.1, 0.5: ");
                            double coin = Convert.ToInt32(Console.ReadLine());
                            coinMoney.Add(coin);
                            payedValue += coin;
                        }
                        break;

                    case 3: {
                            Console.WriteLine("Please enter amount from card: ");
                            double card = Convert.ToInt32(Console.ReadLine());
                            payedValue += card;
                        }
                        break;
                    default:
                        break;
                }
                payment.ValueReceivedMethod(payedValue);
            }

            account.Pay(payment, paperMoney, coinMoney);

            Console.WriteLine("You still want to buy?(yes/no)");
            String decision;
            decision = Console.ReadLine();
            switch (decision) {
                case "no":
                    Console.WriteLine("Thank you for your order. Have a nice day!");
                    break;
                case "yes":
                    Run();
                    break;
                default:
                    Console.WriteLine("Next time please enter yes/no.");
                    break;
            }
        }
    }
}
