using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using blockchainGob.Configuration;

namespace blockchainGob.Web.Host.Startup
{
    [DependsOn(
       typeof(blockchainGobWebCoreModule))]
    public class blockchainGobWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public blockchainGobWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(blockchainGobWebHostModule).GetAssembly());
        }
    }
}
