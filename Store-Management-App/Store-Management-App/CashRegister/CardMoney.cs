using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public class CardMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Card;
        }
    }
}
