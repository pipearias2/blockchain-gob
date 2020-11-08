using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace blockchainGob.Controllers
{
    public abstract class blockchainGobControllerBase: AbpController
    {
        protected blockchainGobControllerBase()
        {
            LocalizationSourceName = blockchainGobConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
