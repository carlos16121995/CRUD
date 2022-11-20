using Bogus;
using CRUD.Domain.Entities.Users.Addresses;
using CRUD.Domain.Enums;
using CRUD.Infrastructure.Persistence;
using CRUD.Test.Core.DataBaseSeeder.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Test.Core.Seeders.Users
{
    public class AddressSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 30;

        public async Task Run(Context context)
        {
            var usersId = await context.Users.Select(u=> u.Id).ToListAsync();
            foreach(var userId in usersId)
                context.Addresses.AddRange(SeedAddress(context, userId));

            await context.SaveChangesAsync();
        }

        public List<Address> SeedAddress(Context context, Guid userId) => new Faker<Address>()
            .RuleFor(c => c.UserId, userId)
            .RuleFor(c => c.CityId, TakeCityRandom(context))
            .RuleFor(c => c.AddressType, f => f.Random.Enum<EAddressType>())
            .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
            .RuleFor(c => c.Street, f => f.Address.StreetAddress())
            .RuleFor(c => c.Neighborhood, f => f.Address.StreetName())
            .RuleFor(c => c.Number, f => f.Address.BuildingNumber())
            .RuleFor(c => c.Complement, f => f.Address.BuildingNumber())
            .RuleFor((p) => p.Activated, true)
            .RuleFor((p) => p.Deleted, false)
            .Generate(10);

        private int TakeCityRandom(Context context) => Random.Shared.Next(1, context.Cities.Count());
    }
}
