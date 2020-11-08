using Abp.Application.Services;
using blockchainGob.MultiTenancy.Dto;

namespace blockchainGob.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

