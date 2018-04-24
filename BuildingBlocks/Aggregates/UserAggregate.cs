using BuildingBlocks.Entities;
using BuildingBlocks.Repositiories;
using BuildingBlocks.ValueObjects;
using System;
using BuildingBlocks.Policies;

namespace BuildingBlocks.Aggregates
{
    //Aggregate root
    public class UserAggregate
    {
        //Repositiories
        private readonly BallancesRepository _ballancesRepo = new BallancesRepository();
        private readonly UsersRepository _usersRepo = new UsersRepository();

        //Policy
        private readonly LogPolicy _logPolicy = new LogPolicy();

        public UserAggregate(Guid userGuid)
        {
            Id = new UserId {Guid = userGuid};

            var ballance = _ballancesRepo.Get(Id);
            Wallet = new WalletAggregate(ballance);

            User = _usersRepo.Get(userGuid);
        }

        //Value Object
        UserId Id{get; }

        // Entities
        User User { get; set; }

        //Aggregate
        WalletAggregate Wallet { get; set; }

        public string UserInfo => User.ToString();
        public string BallanceInfo => Wallet.ToString();

        public string Charge(MoneyValue moneyValue)
        {
            try
            {
                return Wallet.Charge(moneyValue);
            }
            catch (Exception ex)
            {
                _logPolicy.LogException(ex);
                return ex.Message;
            }
        }

        public string Income(MoneyValue moneyValue)
        {
            try
            {
                return Wallet.Income(moneyValue);
            }
            catch (Exception ex)
            {
                _logPolicy.LogException(ex);
                return ex.Message;
            }
        }
    }
}
