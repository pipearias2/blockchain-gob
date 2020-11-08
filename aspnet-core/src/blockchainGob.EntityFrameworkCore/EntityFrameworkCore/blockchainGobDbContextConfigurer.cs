using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace blockchainGob.EntityFrameworkCore
{
    public static class blockchainGobDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<blockchainGobDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<blockchainGobDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
