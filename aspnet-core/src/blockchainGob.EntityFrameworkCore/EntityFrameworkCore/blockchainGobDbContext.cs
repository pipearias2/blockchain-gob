using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using blockchainGob.Authorization.Roles;
using blockchainGob.Authorization.Users;
using blockchainGob.MultiTenancy;

namespace blockchainGob.EntityFrameworkCore
{
    public class blockchainGobDbContext : AbpZeroDbContext<Tenant, Role, User, blockchainGobDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public blockchainGobDbContext(DbContextOptions<blockchainGobDbContext> options)
            : base(options)
        {
        }
    }
}
