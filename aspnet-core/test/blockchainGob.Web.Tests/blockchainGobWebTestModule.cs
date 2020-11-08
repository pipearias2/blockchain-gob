using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using blockchainGob.EntityFrameworkCore;
using blockchainGob.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace blockchainGob.Web.Tests
{
    [DependsOn(
        typeof(blockchainGobWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class blockchainGobWebTestModule : AbpModule
    {
        public blockchainGobWebTestModule(blockchainGobEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(blockchainGobWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(blockchainGobWebMvcModule).Assembly);
        }
    }
}