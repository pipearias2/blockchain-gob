using System.Threading.Tasks;
using blockchainGob.Configuration.Dto;

namespace blockchainGob.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
