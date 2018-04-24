using BuildingBlocks.Entities;
using BuildingBlocks.Policies;
using BuildingBlocks.ValueObjects;
using System;

namespace BuildingBlocks.Aggregates
{
    public class WalletAggregate
    {
        public WalletAggregate(Ballance ballance)
        {
            _ballance = new MoneyValue(ballance.Amount, ballance.Currency);
        }

        //Value Object
        MoneyValue _ballance;

        //Policy
        private readonly CantorPolicy _cantorPolicy = new CantorPolicy();

        public string Income(MoneyValue money)
        {
            money = _cantorPolicy.Exchange(money, Currency.EUR);

            _ballance = new MoneyValue(_ballance.Amount + money.Amount, Currency.EUR);

            return $"Income {money} success! {_currentBalance}";
        }

        public string Charge(MoneyValue money)
        {
            money = _cantorPolicy.Exchange(money, Currency.EUR);

            if (_ballance.CanCharge(money))
            {
                _ballance = new MoneyValue(_ballance.Amount - money.Amount, Currency.EUR);
                return $"Charge {money} success! {_currentBalance}";
            }

            throw new InvalidOperationException($"Charge {money} can't be done on account. Rejected.");
        }

        string _currentBalance => $"Your current ballance is {_ballance}.";

        public override string ToString()
        {
            return _currentBalance;
        }
    }
}