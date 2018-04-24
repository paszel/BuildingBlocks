using BuildingBlocks.Entities;
using BuildingBlocks.ValueObjects;

namespace BuildingBlocks.Repositiories
{
    public class BallancesRepository
    {
        public Ballance Get(UserId userId)
        {
            return new Ballance
            {
                Amount = 10.0M,
                Currency = Currency.EUR,
                UserId = userId.Guid
            };
        }
    }
}
