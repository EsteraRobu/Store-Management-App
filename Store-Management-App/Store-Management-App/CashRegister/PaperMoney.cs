using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public class PaperMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Paper;
        }
        public static Boolean ExistMoneyForValue(double value)
        {
            return (value == 1 || value == 5 || value == 10 || value == 50 || value == 100 || value == 200 || value == 500);

        }
    }
}
