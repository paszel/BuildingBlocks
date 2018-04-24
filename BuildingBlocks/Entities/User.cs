using System;

namespace BuildingBlocks.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Region { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Hi, my name is {FirstName} {LastName}.";
        }
    }
}
