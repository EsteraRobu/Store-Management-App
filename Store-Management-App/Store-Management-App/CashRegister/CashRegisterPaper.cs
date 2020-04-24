using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public class CashRegisterPaper : CashRegister
    {
        public override Money CreateNewMoney()
        {
            return new PaperMoney();
        }

        public override bool ExistMoneyForValue(double value)
        {
            return PaperMoney.ExistMoneyForValue(value);
        }
    }
}
