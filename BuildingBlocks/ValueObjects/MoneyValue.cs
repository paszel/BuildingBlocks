using System;

namespace BuildingBlocks.ValueObjects
{
    // Value Object
    public class MoneyValue
    {
        public MoneyValue(decimal amount, Currency currency)
        {
            _amount = amount;
            _currency = currency;
        }

        private readonly Currency _currency;

        public Currency Currency
        {
            get { return _currency; } 
        }

        private readonly decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

        public bool CanCharge(MoneyValue money)
        {
            if (_currency == money.Currency)
                return Amount - money.Amount > 0;

            throw new ArgumentException($"Different currencies detected. Can't calculate charge.");
        }
    }
}
