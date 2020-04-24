using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public class Cashier 
    {
        private static Cashier instance = null;
        private static readonly object padlock = new object();

        public CashRegisterCoin cashRegisterCoin = new CashRegisterCoin();
        public CashRegisterCard cashRegisterCard = new CashRegisterCard();
        public CashRegisterPaper cashRegisterPaper = new CashRegisterPaper();
        public Cashier() {
            UpdateCashRegister();
        }

        public static Cashier Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Cashier();
                    }
                    return instance;
                }
            }
        }

        private CashRegister getCashRegister(double value, EMoneyType type)
        {
            switch (type)
            {
                case EMoneyType.Coin:
                    return cashRegisterCoin;

                case EMoneyType.Paper:
                    return cashRegisterPaper;

                case EMoneyType.Card:
                    return cashRegisterCard;

                default:
                    return null;


            }
        }
        protected void UpdateCashRegister()
        {
            for (int count = 0; count <= 10; count++)
            {
                CashIn(0.01, EMoneyType.Coin);
                CashIn(0.05, EMoneyType.Coin);
                CashIn(0.1, EMoneyType.Coin);
                CashIn(0.5, EMoneyType.Coin);
                CashIn(1, EMoneyType.Paper);
                CashIn(5, EMoneyType.Paper);
                CashIn(10, EMoneyType.Paper);
                CashIn(50, EMoneyType.Paper);
                CashIn(100, EMoneyType.Paper);
                CashIn(200, EMoneyType.Paper);
                CashIn(500, EMoneyType.Paper);
            }
        }
        public void CashIn(double value, EMoneyType type)
        {
            getCashRegister(value, type).CashIn(value);
        }
        public void CashOut(double value, EMoneyType type)
        {
            getCashRegister(value, type).CashOut(value);
        }

        public double GetTotalCache()
        {
            return cashRegisterCard.GetTotalCache() + cashRegisterPaper.GetTotalCache() + cashRegisterCoin.GetTotalCache();
        }

        public Boolean checkIfPaperCashExist(double money) {
            return cashRegisterPaper.GetTotalCache() > money ? true : false;
        }

        public Boolean checkIfCoinCashExist(double money)
        {
            return cashRegisterCoin.GetTotalCache() > money ? true : false;
        }

        public void RemoveChangeFromCashRegister(double changeExpected)
        {
            double paperMoney = Math.Truncate(changeExpected);
            if (checkIfPaperCashExist(paperMoney)) {
                while (paperMoney != 0)
                {
                    if (paperMoney < 5)
                    {
                        while (paperMoney != 0)
                        {
                            CashOut(1, EMoneyType.Paper);
                            paperMoney--;
                        }
                        break;
                    }
                    if (paperMoney >= 5 && paperMoney < 10)
                    {
                        CashOut(5, EMoneyType.Paper);
                        paperMoney -= 5;
                    }
                    if (paperMoney >= 10 && paperMoney < 50)
                    {
                        while (paperMoney >= 10)
                        {
                            CashOut(10, EMoneyType.Paper);
                            paperMoney -= 10;
                        }
                    }
                    if (paperMoney >= 50 && paperMoney < 100)
                    {
                        CashOut(50, EMoneyType.Paper);
                        paperMoney -= 50;
                    }
                    if (paperMoney >= 100 && paperMoney < 200)
                    {
                        while (paperMoney >= 100)
                        {
                            CashOut(100, EMoneyType.Paper);
                            paperMoney -= 100;
                        }
                    }
                    if (paperMoney == 200)
                    {
                        CashOut(200, EMoneyType.Paper);
                        paperMoney -= 200;
                    }
                    if (paperMoney > 200 && paperMoney < 500)
                    {
                        while (paperMoney > 200)
                        {
                            CashOut(100, EMoneyType.Paper);
                            paperMoney -= 200;
                        }
                    }
                }

               

            }
            double coin = changeExpected - Math.Truncate(changeExpected);
            if (checkIfCoinCashExist(coin))
            {
                while (coin != 0)
                {
                    if (coin < 0.05)
                    {
                        while (paperMoney != 0)
                        {
                            CashOut(0.01, EMoneyType.Coin);
                            paperMoney -= 0.01;
                        }
                    }
                    if(coin>=0.05 && coin < 0.1)
                    {
                        CashOut(0.05, EMoneyType.Coin);
                        coin -= 0.05;
                    }
                    if (coin >= 0.1 && coin < 0.50)
                    {
                        while (coin > 0.1)
                        {
                            CashOut(0.1, EMoneyType.Coin);
                            coin -= 0.1;
                        }
                    }
                    if (coin == 0.50)
                    {
                        CashOut(0.5, EMoneyType.Coin);
                        coin -= 0.5;
                    }

                }
            }
            

            
        }
    }
}
