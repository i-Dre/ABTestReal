using System;
using System.Collections.Generic;
using System.Text;

namespace ABTestRealDB
{
    public static class PGEFContextSeeder
    {
        public static void Seed(PGEFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //context.SaveChanges();
        }
    }
}
