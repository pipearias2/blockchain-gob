using System.Threading.Tasks;
using Abp.Application.Services;
using blockchainGob.Sessions.Dto;

namespace blockchainGob.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
