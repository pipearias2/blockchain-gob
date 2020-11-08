using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using blockchainGob.Authorization;

namespace blockchainGob
{
    [DependsOn(
        typeof(blockchainGobCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class blockchainGobApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<blockchainGobAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(blockchainGobApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
