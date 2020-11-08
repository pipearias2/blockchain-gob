using System.Threading.Tasks;
using Abp.Application.Services;
using blockchainGob.Authorization.Accounts.Dto;

namespace blockchainGob.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
