using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using blockchainGob.Configuration.Dto;

namespace blockchainGob.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : blockchainGobAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
