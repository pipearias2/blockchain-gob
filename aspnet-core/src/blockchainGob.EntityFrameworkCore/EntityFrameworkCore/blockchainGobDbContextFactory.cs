using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using blockchainGob.Configuration;
using blockchainGob.Web;

namespace blockchainGob.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class blockchainGobDbContextFactory : IDesignTimeDbContextFactory<blockchainGobDbContext>
    {
        public blockchainGobDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<blockchainGobDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            blockchainGobDbContextConfigurer.Configure(builder, configuration.GetConnectionString(blockchainGobConsts.ConnectionStringName));

            return new blockchainGobDbContext(builder.Options);
        }
    }
}
