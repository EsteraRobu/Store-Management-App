using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public class Cashier 
    { 
        public CashRegisterCoin cashRegisterCoin = new CashRegisterCoin();
        public CashRegisterCard cashRegisterCard = new CashRegisterCard();
        public CashRegisterPaper cashRegisterPaper = new CashRegisterPaper();
        public Cashier() {
            UpdateCashRegister();
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
        void RemoveChangeFromCashRegister(double  changeExpected)
        {
            double paperMoney = Math.Truncate(changeExpected);
            double coin = changeExpected - Math.Truncate(changeExpected);
            CashOut(coin, EMoneyType.Coin);
            CashOut(paperMoney, EMoneyType.Paper);
            
        }
    }
}
