using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public class CoinMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Coin;
        }
        public static Boolean ExistMoneyForValue(double value)
        {
            return (value == 0.01 || value == 0.05 || value == 0.1 || value == 0.5);

        }
    }
}
