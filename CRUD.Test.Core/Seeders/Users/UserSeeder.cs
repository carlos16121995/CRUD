using Bogus;
using CRUD.Domain.Entities.Users;
using CRUD.Domain.Enums;
using CRUD.Infrastructure.Persistence;
using CRUD.Test.Core.DataBaseSeeder.Abstractions;

namespace CRUD.Test.Core.Seeders.Users
{
    public class UserSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 30;

        public int TotalItems => 30;

        public async Task Run(Context context)
        {
            for (var i = 1; i <= TotalItems; i++)
                context.Users.AddRange(SeedUsers());

            await context.SaveChangesAsync();
        }

        public static User SeedUsers() => new Faker<User>()
            .RuleFor((p) => p.Name, (f) => f.Person.FirstName)
            .RuleFor((p) => p.BirthDate, DateTime.Now.AddYears(-18))
            .RuleFor((p) => p.Gender, f => f.Random.Enum<EGender>())
            .RuleFor((p) => p.Activated, (f) => f.Random.Bool())
            .RuleFor((p) => p.Deleted, false)
            .RuleFor((p) => p.UpdatedAt, (f) => DateTime.UtcNow)
            .RuleFor((p) => p.CreatedAt, (f) => DateTime.UtcNow);
    }
}
