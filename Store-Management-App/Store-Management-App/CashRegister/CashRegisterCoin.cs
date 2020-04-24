using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public class CashRegisterCoin : CashRegister
    {
        public override Money CreateNewMoney()
        {
            return new CoinMoney();
        }

        public override bool ExistMoneyForValue(double value)
        {
            return CoinMoney.ExistMoneyForValue(value);
        }
    }
}
