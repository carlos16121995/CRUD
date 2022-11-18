using Bogus;
using CRUD.Domain.Entities.Users.Addresses;
using CRUD.Domain.Enums;
using CRUD.Infrastructure.Persistence;
using CRUD.Test.Core.DataBaseSeeder.Abstractions;

namespace CRUD.Test.Core.Seeders.Users
{
    public class AddressSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 30;

        public int TotalItems => new UserSeeder().TotalItems;

        public async Task Run(Context context)
        {
            for (var i = 1; i <= TotalItems; i++)
                context.Addresses.AddRange(SeedAddress(context, i));

            await context.SaveChangesAsync();
        }

        public Address SeedAddress(Context context, int i) => new Faker<Address>()
            .RuleFor(c => c.UserId, context.Users.Select(u => u.Id).ToList()[i])
            .RuleFor(c => c.CityId, TakeCityRandom(context))
            .RuleFor(c => c.AddressType, f => f.Random.Enum<EAddressType>())
            .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
            .RuleFor(c => c.Street, f => f.Address.StreetAddress())
            .RuleFor(c => c.Neighborhood, f => f.Address.StreetName())
            .RuleFor(c => c.Number, f => f.Address.BuildingNumber())
            .RuleFor(c => c.Complement, f => f.Address.BuildingNumber());

        private int TakeCityRandom(Context context) => Random.Shared.Next(1, context.Cities.Count());
    }
}
