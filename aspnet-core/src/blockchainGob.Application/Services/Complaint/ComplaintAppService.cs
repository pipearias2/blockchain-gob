using Abp.Application.Services;
using Abp.Domain.Repositories;
using blockchainGob.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blockchainGob.Services.Complaint
{
    public class ComplaintAppService : AsyncCrudAppService<Entities.Complaint, ComplaintDto, Guid>
    {
        public ComplaintAppService(IRepository<Entities.Complaint, Guid> repository) : base(repository)
        {
        }
        public override async Task<ComplaintDto> CreateAsync(ComplaintDto input)
        {
            ComplaintDto complaint = await base.CreateAsync(input);
            //Nethereum.BlockchainProcessing.Services.BlockchainLogProcessingService
            //TODO: crear blockchain to transaction            

            return complaint;
        }
    }
}
