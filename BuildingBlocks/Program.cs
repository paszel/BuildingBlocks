using System;
using BuildingBlocks.Aggregates;
using BuildingBlocks.ValueObjects;

namespace BuildingBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new UserAggregate(Guid.NewGuid());

            Console.WriteLine(user.UserInfo);
            Console.WriteLine(user.BallanceInfo);

            Console.WriteLine("-------------------------------");

            var money = new MoneyValue(10.0M, Currency.EUR);
            Console.WriteLine($"Attemp to add {money}");
            Console.WriteLine(user.Income(money));

            Console.WriteLine("-------------------------------");

            money = new MoneyValue(20.0M, Currency.USD);
            Console.WriteLine($"Attemp to add {money}");
            Console.WriteLine(user.Income(money));

            Console.WriteLine("-------------------------------");

            money = new MoneyValue(30.0M, Currency.PL);
            Console.WriteLine($"Attemp to add {money}");
            Console.WriteLine(user.Income(money));

            Console.WriteLine("-------------------------------");

            money = new MoneyValue(30.0M, Currency.EUR);
            Console.WriteLine($"Attemp to charge {money}");
            Console.WriteLine(user.Charge(money));

            Console.WriteLine("-------------------------------");

            money = new MoneyValue(20.0M, Currency.EUR);
            Console.WriteLine($"Attemp to charge {money}");
            Console.WriteLine(user.Charge(money));

            Console.WriteLine("-------------------------------");

            money = new MoneyValue(10.0M, Currency.PL);
            Console.WriteLine($"Attemp to charge {money}");
            Console.WriteLine(user.Charge(money));

            Console.WriteLine("-------------------------------");

            Console.WriteLine(user.BallanceInfo);
            
            Console.ReadLine();
        }
    }
}
