using System;

namespace BuildingBlocks.Entities
{
    public class Ballance
    {
        public Currency Currency { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
