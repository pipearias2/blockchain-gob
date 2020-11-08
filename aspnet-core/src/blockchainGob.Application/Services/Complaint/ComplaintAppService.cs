using Abp.Application.Services;
using Abp.Domain.Repositories;
using blockchainGob.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blockchainGob.Services.Complaint
{
    public class ComplaintAppService : AsyncCrudAppService<Entities.Complaint, ComplaintDto, long>
    {
        public ComplaintAppService(IRepository<Entities.Complaint, long> repository) : base(repository)
        {
        }
        public override async Task<ComplaintDto> CreateAsync(ComplaintDto input)
        {
            ComplaintDto complaint = await base.CreateAsync(input);

            //TODO: crear blockchain to transaction            

            return complaint;
        }
    }
}
