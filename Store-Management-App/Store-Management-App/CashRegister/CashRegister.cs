using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.CashRegister
{
    public abstract class CashRegister
    {
        private Dictionary<double, Money> _cashMoney;
        private Money _cardMoney;

        public CashRegister()
        {
            _cashMoney = new Dictionary<double, Money>();
        }
        
        protected Money Lookup(double value)
        {
            if (ExistMoneyForValue(value))
            {
                if (!_cashMoney.ContainsKey(value))
                {

                    _cashMoney.Add(value, CreateNewMoney());
                }
                return _cashMoney[value];
            }
            else
            {
                if (_cardMoney == null)
                {
                    _cardMoney = CreateNewMoney();

                }
                return _cardMoney;
            }



        }
        public void CashIn(double value)
        {
            var money = Lookup(value);
            money.TotalCacheValue += value;
        }
        public void CashOut(double value)
        {
            var money = Lookup(value);
            if (money.TotalCacheValue >= value)
                money.TotalCacheValue -= value;
            else
                Console.WriteLine("we do not have cash amound for:" + value);

        }
        public double GetTotalCache()
        {
            double sum = 0;
            foreach (var cache in _cashMoney)
                sum += cache.Value.TotalCacheValue;
            return sum;
        }
        public abstract Money CreateNewMoney();

        public abstract Boolean ExistMoneyForValue(double value);

    }
}
