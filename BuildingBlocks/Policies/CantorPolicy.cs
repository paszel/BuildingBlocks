using System;
using System.Collections.Generic;
using BuildingBlocks.ValueObjects;

namespace BuildingBlocks.Policies
{
    public class CantorPolicy
    {
        private readonly Dictionary<Tuple<Currency, Currency>, decimal> _exchangeRates = new Dictionary<Tuple<Currency, Currency>, decimal>
        {
            {Tuple.Create(Currency.PL, Currency.EUR), 0.239716M},
            {Tuple.Create(Currency.PL, Currency.USD), 0.293982M},
            {Tuple.Create(Currency.EUR, Currency.PL), 4.17139M},
            {Tuple.Create(Currency.EUR, Currency.USD), 1.22669M},
            {Tuple.Create(Currency.USD, Currency.PL), 3.40103M},
            {Tuple.Create(Currency.USD, Currency.EUR), 0.8152220M}
        };

        public MoneyValue Exchange(MoneyValue moneyValue, Currency toCurrency)
        {
            if (moneyValue == null)
                throw new ArgumentException("Money value can not be null");

            if (moneyValue.Currency == toCurrency)
                return moneyValue;

            var rateTuple = Tuple.Create(moneyValue.Currency, toCurrency);

            var exchangeRate = ExchangeRateFor(rateTuple);

            var round = decimal.Round(moneyValue.Amount*exchangeRate, 2, MidpointRounding.AwayFromZero);

            return new MoneyValue(round, toCurrency);
        }

        private decimal ExchangeRateFor(Tuple<Currency, Currency> rateTuple)
        {
            if (_exchangeRates.ContainsKey(rateTuple))
            {
                return _exchangeRates[rateTuple];
            }

            throw new ArgumentNullException($"Exchange rage not found from {rateTuple.Item1} to {rateTuple.Item2}.");
        }

        
        
        
    }
}