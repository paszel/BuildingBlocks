using System;
using BuildingBlocks.Entities;

namespace BuildingBlocks.Repositiories
{
    public class UsersRepository
    {
        public User Get(Guid id)
        {
            return new User
            {
                Id = id,
                FirstName = "Jhon",
                LastName = "Lemon",
                Region = "PL-pl"
            };
        }
    }
}
