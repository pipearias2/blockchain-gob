using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using blockchainGob.Authorization.Roles;
using blockchainGob.Authorization.Users;
using blockchainGob.MultiTenancy;
using blockchainGob.Entities;

namespace blockchainGob.EntityFrameworkCore
{
    public class blockchainGobDbContext : AbpZeroDbContext<Tenant, Role, User, blockchainGobDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Complaint> Complaint { get; set; }

        public blockchainGobDbContext(DbContextOptions<blockchainGobDbContext> options)
            : base(options)
        {
        }
    }
}
