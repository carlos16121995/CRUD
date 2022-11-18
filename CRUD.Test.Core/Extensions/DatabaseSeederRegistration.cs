// Copyright (c) 2022, Vendi Porque Cresci™. All rights reserved.
// Copyright (c) 2022, Marttech Desenvolvimento de Software. All rights reserved.
// PRIVATE SOURCE. Any kind of unauthorized use is prohibited.

using CRUD.Infrastructure.Persistence;
using CRUD.Test.Core.DataBaseSeeder;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Test.Core.Extensions
{
    public static class DatabaseSeederRegistration
    {
        public static void SeedInMemoryDatabase(this IServiceProvider provider)
            => provider.InitializeDatabase<Context, AvatarSeeder>();
    }
}
